using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public class VisitController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INewVisitService _newVisitService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlHelper _urlHelper;
        private readonly IErrorService _errorService;

        public VisitController(IUnitOfWork unitOfWork,
            INewVisitService newVisitService,
            IMapper mapper,
            IUrlHelper linkService,
            IErrorService errorService)
        {
            _errorService = errorService;
            _urlHelper = linkService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _newVisitService = newVisitService;
        }

        public async Task<IActionResult> GetBySearch(VisitDataSearchFilter filter)
        {
            var visitStubs = (await _unitOfWork.Visits.FilteredSearch(filter))
                .Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit));

            var visitResources = new List<VisitResource>();
            foreach (var visitStub in visitStubs)
            {
                var patientEntity = await _unitOfWork.Patients.FindByGuid(visitStub.PatientGuid);
                var patientStub = _mapper.Map<PatientEntity, PatientStub>(patientEntity);
                visitResources.Add(GenerateVisitResource(visitStub, patientStub));
            }

            return Ok(visitResources);
        }


        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            try
            {
                var patientEntity = await _unitOfWork.Patients.FindByVisit(guid);
                var patientStub = _mapper.Map<PatientEntity, PatientStub>(patientEntity);

                return Ok(new VisitResource
                {
                    Properties = _mapper.Map<VisitEntity, VisitStub>(await _unitOfWork.Visits.FindByGuid(guid)),
                    Patient = patientStub,
                    Links = GenerateVisitLinks(
                        _mapper.Map<VisitEntity, VisitStub>(await _unitOfWork.Visits.FindByGuid(guid)))
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitNotFoundInRepository)
                    .HasInternalMessage($"Guid {guid} is not valid.")
                    .TellsUser("We were not able to process the request due it's improper formatting.")
                    .Build();
                
                return BadRequest(error);
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.RepositoryEntityNotFound)
                    .HasInternalMessage($"A entity with Guid {guid} could not be located in the repository.")
                    .TellsUser($"We were not able to locate the requested visit")
                    .Build();
                
                return NotFound(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VisitStubFromUser visitStub)
        {
            if (!ModelState.IsValid)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitDataFromUserIsInvalid)
                    .HasInternalMessage("The data model supplied did not pass model validation. The resource was therefore not created.")
                    .TellsUser("The information provided is not properly formatted and the visit was not created.")
                    .Build();

                return BadRequest(error);
            }
            
            var newVisitEntity = _mapper.Map<VisitStubFromUser, VisitEntity>(visitStub);
            try
            {
                var newVisit = await _newVisitService
                    .WithUnitOfWork(_unitOfWork)
                    .UsingTemplatePatientEntity(newVisitEntity);

                await _unitOfWork.Visits.Add(newVisit);
                await _unitOfWork.Complete();
                return Created(nameof(Post), newVisit);
            }
            catch (FormatException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.PatientReceivedWithEmptyGuid)
                    .HasInternalMessage("The patient has an empty Guid which is not acceptable.")
                    .TellsUser(
                        "The patent information was not formatted properly, it is missing critical identifying information")
                    .Build();
                return BadRequest(error);
            }
            catch (ArgumentNullException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitDataFromUserIsInvalid)
                    .HasInternalMessage("The visit was received as null. No resource was created.")
                    .TellsUser("The visit could not be created becuase the request was not properly formatted")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPut]
        [Route("{guid}")]
        public async Task<IActionResult> Put(Guid guid, [FromBody] VisitStubFromUser entity)
        {
            if (!ModelState.IsValid)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitDataFromUserIsInvalid)
                    .HasInternalMessage("The data model supplied did not pass model validation and could not be updated.")
                    .TellsUser("The information provided is not properly formatted and therefore it could not be updated.")
                    .Build();

                return BadRequest(error);
            }

            try
            {
                var updatedEntity = _mapper.Map<VisitStubFromUser, VisitEntity>(entity);
                var trackedEntity = await _unitOfWork.Visits.FindByGuid(entity.Guid);
                trackedEntity.MapValues(updatedEntity);
                await _unitOfWork.Visits.Update(trackedEntity);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitNotFoundInRepository)
                    .HasInternalMessage($"Visit {entity.Guid} could not be located. No resource was updated.")
                    .TellsUser($"There was an error locating the visit and we could not update it.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                var trackedEntity = await _unitOfWork.Visits.FindByGuid(guid);
                await _unitOfWork.Visits.Delete(trackedEntity.Id);
                await _unitOfWork.Complete();
                return NoContent();
            }
            catch (RepositoryEntityNotFoundException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.VisitNotFoundInRepository)
                    .HasInternalMessage($"Visit {guid} could not be located. No resource was updated.")
                    .TellsUser($"There was an error locating the visit and we could not update it.")
                    .Build();
                return BadRequest(error);
            }
        }


        private VisitResource GenerateVisitResource(VisitStub visitStub, PatientStub patientResource)
        {
            return new VisitResource
            {
                Properties = visitStub,
                Patient = patientResource,
                Links = GenerateVisitLinks(visitStub)
            };
        }

        private List<ResourceLink> GenerateVisitLinks(VisitStub visitStub)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = $"Search for visits",
                    Relationship = UrlRelationship.Search,
                    Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null)),
                    HtmlMethod = HtmlMethod.Post
                },
                new ResourceLink
                {
                    Description = $"Get this visit",
                    Relationship = UrlRelationship.Next,
                    Href = _urlHelper.Action<VisitController>(a => a.GetByGuid(visitStub.Guid)),
                    HtmlMethod = HtmlMethod.Get
                }
            };
        }
    }
}