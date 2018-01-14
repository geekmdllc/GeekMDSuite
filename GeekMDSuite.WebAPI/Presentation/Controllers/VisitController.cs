using System;
using System.Collections.Generic;
using System.IO;
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
    public class VisitController : Controller
    {
        public VisitController(IUnitOfWork unitOfWork, 
            INewVisitService newVisitService, 
            IMapper mapper,
            IUrlHelper linkService)
        {
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
                var patientStub = _mapper.Map<PatientEntity, PatientStub>(await _unitOfWork.Patients.FindByGuid(visitStub.PatientGuid));
                visitResources.Add(GenerateVisitResource(visitStub, patientStub));
            }
            return Ok(visitResources);
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> GetByVisitGuid(Guid guid)
        {
            try
            {
                var visitStub = _mapper.Map<VisitEntity, VisitStub>(await _unitOfWork.Visits.FindByGuid(guid));
                var patientEntity = await _unitOfWork.Patients.FindByGuid((await _unitOfWork.Visits.FindByGuid(guid)).PatientGuid);
                var patient = _mapper.Map<PatientEntity, PatientStub>(patientEntity);
                
                var links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Relationship = UrlRelationship.Self,
                        Href = _urlHelper.Action<VisitController>(a => a.GetByVisitGuid(visitStub.VisitId))
                    },
                    new ResourceLink
                    {
                        Relationship = UrlRelationship.Prev,
                        Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null))
                    }
                };

                return Ok(new VisitResource
                {
                    Visit = visitStub,
                    Patient = patient,
                    Links = links
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("An emtpy Guid was provided.");
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VisitStub visitStub)
        {
            var newVisitEntity = _mapper.Map<VisitStub, VisitEntity>(visitStub);
            try
            {
                var newVisit = await _newVisitService
                    .WithUnitOfWork(_unitOfWork)
                    .UsingTemplatePatient(newVisitEntity);

                await _unitOfWork.Visits.Add(newVisit);
                await _unitOfWork.Complete();
                return Ok(newVisit);
            }
            catch (InvalidDataException)
            {
                return BadRequest("PatientGuid is empty.");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"{nameof(VisitEntity)} is malformed.");
            }
        }
        
        [HttpPut]
        [Route("{guid}")]
        public async Task<IActionResult> Put(Guid guid, [FromBody] VisitStub entity)
        {
            var updatedEntity = _mapper.Map<VisitStub, VisitEntity>(entity);
            var trackedEntity = await _unitOfWork.Visits.FindByGuid(entity.VisitId);
            trackedEntity.MapValues(updatedEntity);
            
            try
            {
                await _unitOfWork.Visits.Update(trackedEntity);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A null entity was provided.");
            }
        }

        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var trackedEntity = await _unitOfWork.Visits.FindByGuid(guid);
            try
            {
                await _unitOfWork.Visits.Delete(trackedEntity.Id);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        private readonly INewVisitService _newVisitService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlHelper _urlHelper;
        
        
        private VisitResource GenerateVisitResource(VisitStub visitStub, PatientStub patientStub)
        {
            return new VisitResource
            {
                Visit = visitStub,
                Patient = patientStub,
                Links = GenerateVisitLinks(visitStub, patientStub)
            };
        }

        private List<ResourceLink> GenerateVisitLinks(VisitStub visitStub, PatientStub patientStub)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = $"GET filterable list of visits",
                    Relationship = UrlRelationship.Self,
                    Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null))
                },
                new ResourceLink
                {
                    Description = $"GET, PUT, DELETE visit {visitStub.VisitId}",
                    Relationship = UrlRelationship.Next,
                    Href = _urlHelper.Action<VisitController>(a => a.GetByVisitGuid(visitStub.VisitId))
                },
                new ResourceLink
                {
                    Description = $"GET, PUT, DELETE patient {patientStub.Guid}",
                    Relationship = UrlRelationship.Next,
                    Href = _urlHelper.Action<PatientController>(a => a.GetByGuid(visitStub.PatientGuid))
                }
            };
        }
    }
}