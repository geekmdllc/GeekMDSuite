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
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public class PatientController : EntityDataController
    {
        private readonly INewPatientService _newPatientService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlHelper _urlHelper;

        public PatientController(IUnitOfWork unitOfWork, 
            INewPatientService newPatientService, 
            IMapper mapper,
            IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _newPatientService = newPatientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBySearch(PatientDataSearchFilter filter)
        {
            var patientResourceSelectionAsync = 
                (await _unitOfWork.Patients.Search(filter))
                .Select(patient => _mapper.Map<PatientEntity, PatientStub>(patient))
                .Select(async patient => new PatientResource
                {
                    Patient = patient,
                    Visits = await MapVisitStubs(patient),
                    Links = new List<ResourceLink>
                    {
                         new ResourceLink
                         {
                             Rel = UrlRelationship.Child,
                             Href = _urlHelper.Action<PatientController>(a => a.GetVisits(patient.Guid))
                         },
                        new ResourceLink
                        {
                            Rel = UrlRelationship.Self,
                            Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(patient.Guid))
                        }
                    }
                }
            );

            var patientResources = await Task.WhenAll(patientResourceSelectionAsync);
            return Ok(patientResources);
        }

        private async Task<List<VisitStub>> MapVisitStubs(PatientStub patient)
        {
            var visits = (await _unitOfWork.Visits.All()).Where(visit => visit.PatientGuid == patient.Guid);
            var visitStubs = visits.Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit));
            return visitStubs.ToList();
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            try
            {
                var patient = await _unitOfWork.Patients.FindByGuid(guid);
                var visits = (await _unitOfWork.Visits.All()).Where(v => v.PatientGuid == guid);

                var links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Rel = UrlRelationship.Child, 
                        Href = _urlHelper.Action<PatientController>(a => a.GetVisits(patient.Guid))
                    },
                    new ResourceLink
                    {
                        Rel = UrlRelationship.Self,
                        Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(patient.Guid))
                    },
                    new ResourceLink
                    {
                        Rel = UrlRelationship.Parent,
                        Href = _urlHelper.Action<PatientController>(a => a.GetBySearch(null))
                    }
                };
                
                return Ok(new PatientResource
                {
                    Patient = _mapper.Map<PatientEntity, PatientStub>(patient), 
                    Visits = visits.Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit)).ToList(), 
                    Links = links
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("An empty Guid was provided.");
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientStub patient)
        {
            var newPatientEntity = _mapper.Map<PatientStub, PatientEntity>(patient);
            try
            {
                var newPatient = await _newPatientService
                    .WithUnitOfWork(_unitOfWork)
                    .UsingTemplatePatient(newPatientEntity);
                
                await _unitOfWork.Patients.Add(newPatient);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (MedicalRecordAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{guid}")]
        public async Task<IActionResult> Put(Guid guid, [FromBody] PatientStub patientStub)
        {
            var trackedPatient = await _unitOfWork.Patients.FindByGuid(guid);
            var updatedPatient = _mapper.Map<PatientStub, PatientEntity>(patientStub);
            
            trackedPatient.MapValues(updatedPatient);
            await _unitOfWork.Complete();
            return Ok(_mapper.Map<PatientEntity, PatientStub>(trackedPatient));
        }
        
        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var trackedPatient = await _unitOfWork.Patients.FindByGuid(guid);
            await _unitOfWork.Patients.Delete(trackedPatient.Id);
            await _unitOfWork.Complete();
            
            return NoContent();
        }
                
        [HttpGet]
        [Route("{guid}/visits")]
        public async Task<IActionResult> GetVisits(Guid guid)
        {                      
            var patient = await _unitOfWork.Patients.FindByGuid(guid);
            var visitEntities = (await _unitOfWork.Visits.All()).Where(v => v.PatientGuid == guid);
            var visitStubs = visitEntities.Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit));
            
            return Ok(visitStubs);
        }

    }
}