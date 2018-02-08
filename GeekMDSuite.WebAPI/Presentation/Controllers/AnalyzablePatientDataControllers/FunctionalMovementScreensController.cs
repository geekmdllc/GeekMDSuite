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
    public class FunctionalMovementScreensController : VisitDataController
    {
        public FunctionalMovementScreensController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(unitOfWork, mapper, errorService)
        {
        }
        
        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredEntities<FunctionalMovementScreenEntity>(filter);
            
            var resources = GenerateFunctionalMovementScreenResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await UnitOfWork.FunctionalMovementScreens.FindById(id);
                var stub = Mapper.Map<FunctionalMovementScreenEntity, FunctionalMovementScreenStub>(entity);
                var resource = new FunctionalMovementScreenResource
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
                    .HasInternalMessage($"An functional movement screen entity with the id {id} could not be located in the repository.")
                    .TellsUser("The requested functional movement screen entry could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Post([FromBody] FunctionalMovementScreenStubFromUser stub)
        {
            try
            {
                var entity = Mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenEntity>(stub);
                await UnitOfWork.FunctionalMovementScreens.Add(entity);
                await UnitOfWork.Complete();
                var url = Url.Action<FunctionalMovementScreensController>(a => a.Post(stub));
                return Created(url, entity);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage(
                        "A null object was included in the request body and cannot be processed as an functional movement screen entity")
                    .TellsUser(
                        "The request to create a new functional movement screen entry was malformed and likely empty. Please retry.")
                    .Build();
                return BadRequest(error);
            }
            catch (EntityNotUniqeException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage(
                        $"The object provided in the request body has id {stub.Id} and already exists in the repository. Either this is not a new object, or the new object was incorrectly formatted. In order for the object to be created correctly it should be 0")
                    .TellsUser("The request to create a new functional movement screen entry was imporoperly formatted ")
                    .Build();
                return Conflict(error);
            }
            catch (InvalidDataException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The functional movement screen data model receieved is not associated with a valid visit Guid")
                    .TellsUser("The functional movement screen recieved is not properly associated with a visit and could not be added")
                    .Build();
                    
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Put(int id, [FromBody] FunctionalMovementScreenStubFromUser stub)
        {
            if (stub != null && id != stub.Id)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.WrongApiEndpointTargeted)
                    .HasInternalMessage($"There endpoint targeted a functional movement screen entity with Id {id}, but the functional movement screen resource object contained Id {stub.Id}")
                    .TellsUser("The functional movement screen entry provided for update doesn't match the intended target.")
                    .Build();

                return BadRequest(error);
            }
            
            try
            {
                var entity = Mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenEntity>(stub);
                await UnitOfWork.FunctionalMovementScreens.Update(entity);
                await UnitOfWork.Complete();
                return Ok(stub);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"An functional movement screen entity with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The request could not be processed because the functional movement screen entry identified for update couldn't not be found")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The functional movement screen data model received from client was null and could not be processed.")
                    .TellsUser("The request to createa a new functional movement screen was improperly formatted")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.FunctionalMovementScreens.Delete(id);
                await UnitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"An functional movement screen element with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The requested functional movement screen resource could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        private IEnumerable<FunctionalMovementScreenResource> GenerateFunctionalMovementScreenResources(IEnumerable<FunctionalMovementScreenEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<FunctionalMovementScreenEntity, FunctionalMovementScreenStub>);
            var resources = stubs.Select(stub => new FunctionalMovementScreenResource
            {
                Properties = stub,
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Description = "Get this functional movement screen resource",
                        Href = Url.Action<FunctionalMovementScreensController>(a => a.GetById(stub.Id)),
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
                    Description = "Get functional movement screen resource by it's unique identifier.",
                    Href = Url.Action<FunctionalMovementScreensController>(a => a.GetById(id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Delete functional movement screen resource by it's unique identifier.",
                    Href = Url.Action<FunctionalMovementScreensController>(a => a.Delete(id)),
                    HtmlMethod = HtmlMethod.Delete,
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Update the values for this existing functional movement screen resource",
                    Href = Url.Action<FunctionalMovementScreensController>(a => a.Put(id, With.No<FunctionalMovementScreenStubFromUser>())),
                    HtmlMethod = HtmlMethod.Put,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Search for FunctionalMovementScreens resources with filters and pagination",
                    Href = Url.Action<FunctionalMovementScreensController>(a => a.GetBySearch(With.No<EntityDataFindFilter>())),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Add a new functional movement screen resource",
                    Href = Url.Action<FunctionalMovementScreensController>(a => a.Post(With.No<FunctionalMovementScreenStubFromUser>())),
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