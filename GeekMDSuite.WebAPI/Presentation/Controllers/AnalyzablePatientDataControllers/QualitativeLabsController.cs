using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
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
    public class QualitativeLabsController : VisitDataController
    {
        public QualitativeLabsController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(unitOfWork, mapper, errorService)
        {
        }
        
        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredEntities<QualitativeLabEntity>(filter);
            
            var resources = GenerateQualitativeLabsResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await UnitOfWork.QualitativeLabs.FindById(id);
                var stub = Mapper.Map<QualitativeLabEntity, QualitativeLabsStub>(entity);
                var resource = new QualitativeLabsResource
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
                    .HasInternalMessage($"An blood pressure entity with the id {id} could not be located in the repository.")
                    .TellsUser("The requested blood pressure entry could not be found")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Post([FromBody] QualitativeLabsStubFromUser stub)
        {
            try
            {
                var entity = Mapper.Map<QualitativeLabsStubFromUser, QualitativeLabEntity>(stub);
                await UnitOfWork.QualitativeLabs.Add(entity);
                await UnitOfWork.Complete();
                var url = Url.Action<QualitativeLabsController>(a => a.Post(stub));
                return Created(url, entity);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("A null object was included in the request body and cannot be processed as a blood pressure entity") 
                    .TellsUser("The request to create a new blood pressure entry was malformed and likely empty. Please retry.")
                    .Build();
                return BadRequest(error);
            }
            catch (EntityNotUniqeException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage($"The object provided in the request body has id {stub.Id} and already exists in the repository. Either this is not a new object, or the new object was incorrectly formatted. In order for the object to be created correctly it should be 0") 
                    .TellsUser("The request to create a new blood pressure entry was imporoperly formatted ")
                    .Build();
                return Conflict(error);
            }
            catch (InvalidDataException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The blood pressure data model receieved is not associated with a valid visit Guid")
                    .TellsUser("The blood pressure recieved is not properly associated with a visit and could not be added")
                    .Build();
                    
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Put(int id, [FromBody] QualitativeLabsStubFromUser stub)
        {
            if (stub != null && id != stub.Id)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.WrongApiEndpointTargeted)
                    .HasInternalMessage($"There endpoint targeted a blood pressure entity with Id {id}, but the blood pressure resource object contained Id {stub.Id}")
                    .TellsUser("The blood pressure entry provided for update doesn't match the intended target.")
                    .Build();

                return BadRequest(error);
            }
            
            try
            {
                var entity = Mapper.Map<QualitativeLabsStubFromUser, QualitativeLabEntity>(stub);
                await UnitOfWork.QualitativeLabs.Update(entity);
                await UnitOfWork.Complete();
                return Ok(stub);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"A blood pressure entity with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The request could not be processed because the blood pressure entry identified for update couldn't not be found")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The blood pressure data model received from client was null and could not be processed.")
                    .TellsUser("The request to createa a new blood pressure was improperly formatted")
                    .Build();
                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.QualitativeLabs.Delete(id);
                await UnitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = ErrorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"A blood pressure element with Id {id} could not be located in the repository. No changes were made.")
                    .TellsUser("The requested blood pressure resource could not be found")
                    .Build();
                return BadRequest(error);
            }
        }
        
        private List<ResourceLink> GenerateGetByIdLinks(int id)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get blood pressure resource by it's unique identifier.",
                    Href = Url.Action<QualitativeLabsController>(a => a.GetById(id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Delete blood pressure resource by it's unique identifier.",
                    Href = Url.Action<QualitativeLabsController>(a => a.Delete(id)),
                    HtmlMethod = HtmlMethod.Delete,
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Update the values for this existing blood pressure resource",
                    Href = Url.Action<QualitativeLabsController>(a => a.Put(id, With.No<QualitativeLabsStubFromUser>())),
                    HtmlMethod = HtmlMethod.Put,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Search for blood pressures resources with filters and pagination",
                    Href = Url.Action<QualitativeLabsController>(a => a.GetBySearch(With.No<EntityDataFindFilter>())),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Add a new blood pressure resource",
                    Href = Url.Action<QualitativeLabsController>(a => a.Post(With.No<QualitativeLabsStubFromUser>())),
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

        private List<ResourceLink> GenerateLinksForGetBySearch(IEntity stub)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get this blood pressure resource",
                    Href = Url.Action<QualitativeLabsController>(a => a.GetById(stub.Id)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Next
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

        private IEnumerable<QualitativeLabsResource> GenerateQualitativeLabsResources(IEnumerable<QualitativeLabEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<QualitativeLabEntity, QualitativeLabsStub>);
            var resources = stubs.Select(stub => new QualitativeLabsResource
            {
                Links = GenerateLinksForGetBySearch(stub),
                Properties = stub
            });
            return resources;
        }
    }
}