using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class GripStrengthsController : VisitDataController
    {
        public GripStrengthsController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(
            unitOfWork, mapper, errorService)
        {
        }

        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredEntities<GripStrengthEntity>(filter);

            var resources = GenerateGripStrengthResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await UnitOfWork.GripStrengths.FindById(id);
                var stub = Mapper.Map<GripStrengthEntity, GripStrengthStub>(entity);
                var resource = new GripStrengthResource
                {
                    Links = GenerateGetByIdLinks(id),
                    Properties = stub
                };

                return Ok(resource);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage(
                        $"An grip strength entity with the id {id} could not be located in the repository.")
                    .TellsUser("The requested grip strength entry could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Post([FromBody] GripStrengthStubFromUser stub)
        {
            try
            {
                var entity = Mapper.Map<GripStrengthStubFromUser, GripStrengthEntity>(stub);
                await UnitOfWork.GripStrengths.Add(entity);
                await UnitOfWork.Complete();
                var url = Url.Action<GripStrengthsController>(a => a.Post(stub));
                return Created(url, entity);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "A null object was included in the request body and cannot be processed as an grip strength entity")
                    .TellsUser(
                        "The request to create a new grip strength entry was malformed and likely empty. Please retry.")
                    .Build();
                return BadRequest(error);
            }
            catch (EntityNotUniqeException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage(
                        $"The object provided in the request body has id {stub.Id} and already exists in the repository. Either this is not a new object, or the new object was incorrectly formatted. In order for the object to be created correctly it should be 0")
                    .TellsUser("The request to create a new grip strength entry was imporoperly formatted ")
                    .Build();
                return Conflict(error);
            }
            catch (InvalidDataException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "The grip strength data model receieved is not associated with a valid visit Guid")
                    .TellsUser(
                        "The grip strength recieved is not properly associated with a visit and could not be added")
                    .Build();

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Put(int id, [FromBody] GripStrengthStubFromUser stub)
        {
            if (stub != null && id != stub.Id)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.WrongApiEndpointTargeted)
                    .HasInternalMessage(
                        $"There endpoint targeted a grip strength entity with Id {id}, but the grip strength resource object contained Id {stub.Id}")
                    .TellsUser("The grip strength entry provided for update doesn't match the intended target.")
                    .Build();

                return BadRequest(error);
            }

            try
            {
                var entity = Mapper.Map<GripStrengthStubFromUser, GripStrengthEntity>(stub);
                await UnitOfWork.GripStrengths.Update(entity);
                await UnitOfWork.Complete();
                return Ok(stub);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage(
                        $"An grip strength entity with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser(
                        "The request could not be processed because the grip strength entry identified for update couldn't not be found")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "The grip strength data model received from client was null and could not be processed.")
                    .TellsUser("The request to createa a new grip strength was improperly formatted")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.GripStrengths.Delete(id);
                await UnitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage(
                        $"An grip strength element with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The requested grip strength resource could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        private IEnumerable<GripStrengthResource> GenerateGripStrengthResources(
            IEnumerable<GripStrengthEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<GripStrengthEntity, GripStrengthStub>);
            var resources = stubs.Select(stub => new GripStrengthResource
            {
                Properties = stub,
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Description = "Get this grip strength resource",
                        Href = Url.Action<GripStrengthsController>(a => a.GetById(stub.Id)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    new ResourceLink
                    {
                        Description = "Go to the application data root",
                        Href = Url.Action<DataController>(a => a.Get()),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    }
                }
            });

            return resources;
        }

        private List<ResourceLink> GenerateGetByIdLinks(int id)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get grip strength resource by it's unique identifier.",
                    Href = Url.Action<GripStrengthsController>(a => a.GetById(id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Delete grip strength resource by it's unique identifier.",
                    Href = Url.Action<GripStrengthsController>(a => a.Delete(id)),
                    HtmlMethod = HtmlMethod.Delete,
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Update the values for this existing grip strength resource",
                    Href = Url.Action<GripStrengthsController>(a => a.Put(id, With.No<GripStrengthStubFromUser>())),
                    HtmlMethod = HtmlMethod.Put,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Search for GripStrengths resources with filters and pagination",
                    Href = Url.Action<GripStrengthsController>(a => a.GetBySearch(With.No<EntityDataFindFilter>())),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Add a new grip strength resource",
                    Href = Url.Action<GripStrengthsController>(a => a.Post(With.No<GripStrengthStubFromUser>())),
                    HtmlMethod = HtmlMethod.Post,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Go to the application data root",
                    Href = Url.Action<DataController>(a => a.Get()),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Up
                }
            };
        }
    }
}