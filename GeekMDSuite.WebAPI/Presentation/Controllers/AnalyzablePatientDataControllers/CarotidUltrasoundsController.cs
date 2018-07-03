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
    public class CarotidUltrasoundsController : VisitDataController
    {
        public CarotidUltrasoundsController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(
            unitOfWork, mapper, errorService)
        {
        }

        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredEntities<CarotidUltrasoundEntity>(filter);

            var resources = GenerateCarotidUltrasoundResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await UnitOfWork.CarotidUltrasounds.FindById(id);
                var stub = Mapper.Map<CarotidUltrasoundEntity, CarotidUltrasoundStub>(entity);
                var resource = new CarotidUltrasoundResource
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
                        $"A carotid ultrasound entity with the id {id} could not be located in the repository.")
                    .TellsUser("The requested carotid ultrasound entry could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Post([FromBody] CarotidUltrasoundStubFromUser stub)
        {
            try
            {
                var entity = Mapper.Map<CarotidUltrasoundStubFromUser, CarotidUltrasoundEntity>(stub);
                await UnitOfWork.CarotidUltrasounds.Add(entity);
                await UnitOfWork.Complete();
                var url = Url.Action<CarotidUltrasoundsController>(a => a.Post(stub));
                return Created(url, entity);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "A null object was included in the request body and cannot be processed as a carotid ultrasound entity")
                    .TellsUser(
                        "The request to create a new carotid ultrasound entry was malformed and likely empty. Please retry.")
                    .Build();
                return BadRequest(error);
            }
            catch (EntityNotUniqeException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage(
                        $"The object provided in the request body has id {stub.Id} and already exists in the repository. Either this is not a new object, or the new object was incorrectly formatted. In order for the object to be created correctly it should be 0")
                    .TellsUser("The request to create a new carotid ultrasound entry was imporoperly formatted ")
                    .Build();
                return Conflict(error);
            }
            catch (InvalidDataException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "The carotid ultrasound data model receieved is not associated with a valid visit Guid")
                    .TellsUser(
                        "The carotid ultrasound recieved is not properly associated with a visit and could not be added")
                    .Build();

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Put(int id, [FromBody] CarotidUltrasoundStubFromUser stub)
        {
            if (stub != null && id != stub.Id)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.WrongApiEndpointTargeted)
                    .HasInternalMessage(
                        $"There endpoint targeted a carotid ultrasound entity with Id {id}, but the carotid ultrasound resource object contained Id {stub.Id}")
                    .TellsUser("The carotid ultrasound entry provided for update doesn't match the intended target.")
                    .Build();

                return BadRequest(error);
            }

            try
            {
                var entity = Mapper.Map<CarotidUltrasoundStubFromUser, CarotidUltrasoundEntity>(stub);
                await UnitOfWork.CarotidUltrasounds.Update(entity);
                await UnitOfWork.Complete();
                return Ok(stub);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage(
                        $"A carotid ultrasound entity with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser(
                        "The request could not be processed because the carotid ultrasound entry identified for update couldn't not be found")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "The carotid ultrasound data model received from client was null and could not be processed.")
                    .TellsUser("The request to create a new carotid ultrasound was improperly formatted.")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.CarotidUltrasounds.Delete(id);
                await UnitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage(
                        $"A carotid ultrasound element with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The requested caroitd ultrasound resource could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        private IEnumerable<CarotidUltrasoundResource> GenerateCarotidUltrasoundResources(
            IEnumerable<CarotidUltrasoundEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<CarotidUltrasoundEntity, CarotidUltrasoundStub>);
            var resources = stubs.Select(stub => new CarotidUltrasoundResource
            {
                Properties = stub,
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Description = "Get this carotid ultrasound resource",
                        Href = Url.Action<CarotidUltrasoundsController>(a => a.GetById(stub.Id)),
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
                    Description = "Get carotid ultrasound resource by it's unique identifier.",
                    Href = Url.Action<CarotidUltrasoundsController>(a => a.GetById(id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Delete carotid ultrasound resource by it's unique identifier.",
                    Href = Url.Action<CarotidUltrasoundsController>(a => a.Delete(id)),
                    HtmlMethod = HtmlMethod.Delete,
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Update the values for this existing carotid ultrasound resource",
                    Href = Url.Action<CarotidUltrasoundsController>(a =>
                        a.Put(id, With.No<CarotidUltrasoundStubFromUser>())),
                    HtmlMethod = HtmlMethod.Put,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Search for carotid ultrasound resources with filters and pagination",
                    Href =
                        Url.Action<CarotidUltrasoundsController>(a => a.GetBySearch(With.No<EntityDataFindFilter>())),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Add a new carotid ultrasound resource",
                    Href = Url.Action<CarotidUltrasoundsController>(a =>
                        a.Post(With.No<CarotidUltrasoundStubFromUser>())),
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