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
    public class IshiharaSixPlateScreensController : VisitDataController
    {
        public IshiharaSixPlateScreensController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(unitOfWork, mapper, errorService)
        {
        }

        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredEntities<IshiharaSixPlateEntity>(filter);
            
            var resources = GenerateIshiharaSixPlateResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await UnitOfWork.IshiharaSixPlates.FindById(id);
                var stub = Mapper.Map<IshiharaSixPlateEntity, IshiharaSixPlateStub>(entity);
                var resource = new IshiharaSixPlateResource
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
                    .HasInternalMessage($"An ishihara six plate screen entity with the id {id} could not be located in the repository.")
                    .TellsUser("The requested ishihara six plate screen entry could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Post([FromBody] IshiharaSixPlateStubFromUser stub)
        {
            try
            {
                var entity = Mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateEntity>(stub);
                await UnitOfWork.IshiharaSixPlates.Add(entity);
                await UnitOfWork.Complete();
                var url = Url.Action<IshiharaSixPlateScreensController>(a => a.Post(stub));
                return Created(url, entity);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "A null object was included in the request body and cannot be processed as an ishihara six plate screen entity")
                    .TellsUser(
                        "The request to create a new ishihara six plate screen entry was malformed and likely empty. Please retry.")
                    .Build();
                return BadRequest(error);
            }
            catch (EntityNotUniqeException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage(
                        $"The object provided in the request body has id {stub.Id} and already exists in the repository. Either this is not a new object, or the new object was incorrectly formatted. In order for the object to be created correctly it should be 0")
                    .TellsUser("The request to create a new ishihara six plate screen entry was imporoperly formatted ")
                    .Build();
                return Conflict(error);
            }
            catch (InvalidDataException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The ishihara six plate screen data model receieved is not associated with a valid visit Guid")
                    .TellsUser("The ishihara six plate screen recieved is not properly associated with a visit and could not be added")
                    .Build();
                    
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Put(int id, [FromBody] IshiharaSixPlateStubFromUser stub)
        {
            if (stub != null && id != stub.Id)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.WrongApiEndpointTargeted)
                    .HasInternalMessage($"There endpoint targeted a ishihara six plate screen entity with Id {id}, but the ishihara six plate screen resource object contained Id {stub.Id}")
                    .TellsUser("The ishihara six plate screen entry provided for update doesn't match the intended target.")
                    .Build();

                return BadRequest(error);
            }
            
            try
            {
                var entity = Mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateEntity>(stub);
                await UnitOfWork.IshiharaSixPlates.Update(entity);
                await UnitOfWork.Complete();
                return Ok(stub);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"An ishihara six plate screen entity with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The request could not be processed because the ishihara six plate screen entry identified for update couldn't not be found")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The ishihara six plate screen data model received from client was null and could not be processed.")
                    .TellsUser("The request to createa a new ishihara six plate screen was improperly formatted")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.IshiharaSixPlates.Delete(id);
                await UnitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"An ishihara six plate screen element with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The requested ishihara six plate screen resource could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        private IEnumerable<IshiharaSixPlateResource> GenerateIshiharaSixPlateResources(IEnumerable<IshiharaSixPlateEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<IshiharaSixPlateEntity, IshiharaSixPlateStub>);
            var resources = stubs.Select(stub => new IshiharaSixPlateResource
            {
                Properties = stub,
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Description = "Get this ishihara six plate screen resource",
                        Href = Url.Action<IshiharaSixPlateScreensController>(a => a.GetById(stub.Id)),
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
                    Description = "Get ishihara six plate screen resource by it's unique identifier.",
                    Href = Url.Action<IshiharaSixPlateScreensController>(a => a.GetById(id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Delete ishihara six plate screen resource by it's unique identifier.",
                    Href = Url.Action<IshiharaSixPlateScreensController>(a => a.Delete(id)),
                    HtmlMethod = HtmlMethod.Delete,
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Update the values for this existing ishihara six plate screen resource",
                    Href = Url.Action<IshiharaSixPlateScreensController>(a => a.Put(id, With.No<IshiharaSixPlateStubFromUser>())),
                    HtmlMethod = HtmlMethod.Put,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Search for IshiharaSixPlates resources with filters and pagination",
                    Href = Url.Action<IshiharaSixPlateScreensController>(a => a.GetBySearch(With.No<EntityDataFindFilter>())),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Add a new ishihara six plate screen resource",
                    Href = Url.Action<IshiharaSixPlateScreensController>(a => a.Post(With.No<IshiharaSixPlateStubFromUser>())),
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