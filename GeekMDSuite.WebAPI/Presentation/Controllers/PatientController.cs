using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
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
            var patientStubs = (await _unitOfWork.Patients.FilteredSearch(filter))
                .Select(patient => _mapper.Map<PatientEntity, PatientStub>(patient))
                .ToList();
            
            UpdatePatientStubSelfLinks(patientStubs);

            var patientResources = await Task.WhenAll(patientStubs.Select(async patient => await GeneratePatientResource(patient)));
            
            return Ok(patientResources);
        }


        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var patientStub = _mapper.Map<PatientEntity, PatientStub>(await _unitOfWork.Patients.FindByGuid(guid));
            
            var patientResource = GeneratePatientResource(patientStub);
            
            return Ok(patientResource);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientStubFromUser patient)
        {
            var newPatientEntity = _mapper.Map<PatientStubFromUser, PatientEntity>(patient);
            var newPatient = await _newPatientService.WithUnitOfWork(_unitOfWork).UsingTemplatePatientEntity(newPatientEntity);
                
            await _unitOfWork.Patients.Add(newPatient);
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut]
        [Route("{guid}")]
        public async Task<IActionResult> Put(Guid guid, [FromBody] PatientStubFromUser patientStub)
        {
            var trackedPatient = await _unitOfWork.Patients.FindByGuid(guid);
            var updatedPatient = _mapper.Map<PatientStubFromUser, PatientEntity>(patientStub);
            
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
            var visitStubs = (await _unitOfWork.Visits.FindByPatient(guid))
                .Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit)).ToList();

            UpdateVisitStubsSelfLinks(visitStubs);

            var visitResources = await CompileVisitResources(visitStubs);
            foreach (var visit in visitResources)
            {
                UpdatePatientStubSelfLinks(visit.Patient.Patient);
                UpdateVisitStubsSelfLinks(visit.Patient.Visits);
            }

            return Ok(visitResources);
        }

        private void UpdateVisitStubsSelfLinks(List<VisitStub> visitStubs)
        {
            foreach (var stub in visitStubs)
            {
                stub.Self = new ResourceLink
                {
                    Description = "Link to self",
                    Href = _urlHelper.Action<VisitController>(a => a.GetByGuid(stub.Guid)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Next
                };
            }
        }

        private async Task<List<VisitResource>> CompileVisitResources(List<VisitStub> visitStubs)
        {
            var visitResources = new List<VisitResource>();
            UpdateVisitStubsSelfLinks(visitStubs);
            foreach (var visitStub in visitStubs)
            {
                var patientEntity = await _unitOfWork.Patients.FindByGuid(visitStub.PatientGuid);
                var patientStub = _mapper.Map<PatientEntity, PatientStub>(patientEntity);
                UpdatePatientStubSelfLinks(patientStub);
                var patientResource = await CreatePatientResource(patientStub);
                visitResources.Add(GenerateVisitResource(visitStub, patientResource));
            }

            return visitResources;
        }

        private async Task<PatientResource> CreatePatientResource(PatientStub patientStub)
        {
            var patientResource = new PatientResource
            {
                Patient = patientStub,
                Visits = (await _unitOfWork.Visits.All())
                    .Where(v => v.PatientGuid == patientStub.Guid)
                    .Select(v => _mapper.Map<VisitEntity, VisitStub>(v)).ToList(),
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Description = "Get patient",
                        Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(patientStub.Guid)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    }
                }
            };
            return patientResource;
        }
        
        private VisitResource GenerateVisitResource(VisitStub visitStub, PatientResource patientResource)
        {
            
            return new VisitResource
            {
                Visit = visitStub,
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
                    Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null))
                },
                new ResourceLink
                {
                    Description = $"Get this visit",
                    Relationship = UrlRelationship.Next,
                    Href = _urlHelper.Action<VisitController>(a => a.GetByGuid(visitStub.Guid))
                }
            };
        }

        private async Task<PatientResource> GeneratePatientResource(PatientStub patient)
        {
            return new PatientResource
            {
                Patient = patient,
                Visits = await MapVisitStubs(patient),
                Links = GeneratePatientResourceLinks(patient)
            };
        }

        private List<ResourceLink> GeneratePatientResourceLinks(PatientStub patient)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = $"Get patient visits",
                    Relationship = UrlRelationship.Next,
                    Href = _urlHelper.Action<PatientController>(a => a.GetVisits(patient.Guid)),
                    HtmlMethod = HtmlMethod.Get
                },
                new ResourceLink
                {
                    Description = $"Get patient",
                    Relationship = UrlRelationship.Self,
                    Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(patient.Guid)),
                    HtmlMethod = HtmlMethod.Put
                },
                new ResourceLink
                {
                    Description = $"Delete patient",
                    Relationship = UrlRelationship.Self,
                    Href = _urlHelper.Action<PatientController>(a => a.Delete(patient.Guid)),
                    HtmlMethod = HtmlMethod.Delete
                },
                new ResourceLink
                {
                    Description = $"Update patient",
                    Relationship = UrlRelationship.Self,
                    Href = _urlHelper.Action<PatientController>(a => a.Put(patient.Guid, null)),
                    HtmlMethod = HtmlMethod.Put
                },
                new ResourceLink
                {
                    Description = $"Create patient",
                    Relationship = UrlRelationship.Up,
                    Href = _urlHelper.Action<PatientController>(a => a.Post(null)),
                    HtmlMethod = HtmlMethod.Post
                },
                new ResourceLink
                {
                    Description = $"Patient search",
                    Relationship = UrlRelationship.Search,
                    Href = _urlHelper.Action<PatientController>(a => a.GetBySearch(null)),
                    HtmlMethod = HtmlMethod.Get
                }
            };
        }

        private async Task<List<VisitStub>> MapVisitStubs(PatientStub patient)
        {
            var visits = (await _unitOfWork.Visits.All()).Where(visit => visit.PatientGuid == patient.Guid);
            var visitStubs = visits.Select(visit => _mapper.Map<VisitEntity, VisitStub>(visit)).ToList();
            foreach (var stub in visitStubs)
            {
                stub.Self = new ResourceLink
                {
                    Description = "Link to self",
                    Href = _urlHelper.Action<VisitController>(a => a.GetByGuid(stub.Guid)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Next
                };
            }
            return visitStubs;
        }
        
        private void UpdatePatientStubSelfLinks(List<PatientStub> patientStubs)
        {
            foreach (var stub in patientStubs)
            {
                stub.Self = new ResourceLink
                {
                    Description = "Link to self",
                    Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(stub.Guid)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Next
                };
            }
        }

        private void UpdatePatientStubSelfLinks(PatientStub patientStub)
        {
            UpdatePatientStubSelfLinks(new List<PatientStub>{patientStub});
        }
    }
}