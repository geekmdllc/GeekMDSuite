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
        private readonly IMapper _mapper;
        private readonly INewVisitService _newVisitService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlHelper _urlHelper;

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
                    Visit = _mapper.Map<VisitEntity, VisitStub>(await _unitOfWork.Visits.FindByGuid(guid)),
                    Patient = patientStub,
                    Links = GenerateVisitLinks(
                        _mapper.Map<VisitEntity, VisitStub>(await _unitOfWork.Visits.FindByGuid(guid)))
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
        public async Task<IActionResult> Post([FromBody] VisitStubFromUser visitStub)
        {
            var newVisitEntity = _mapper.Map<VisitStubFromUser, VisitEntity>(visitStub);
            try
            {
                var newVisit = await _newVisitService
                    .WithUnitOfWork(_unitOfWork)
                    .UsingTemplatePatientEntity(newVisitEntity);

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
        public async Task<IActionResult> Put(Guid guid, [FromBody] VisitStubFromUser entity)
        {
            var updatedEntity = _mapper.Map<VisitStubFromUser, VisitEntity>(entity);
            var trackedEntity = await _unitOfWork.Visits.FindByGuid(entity.Guid);
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
                return NoContent();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        private VisitResource GenerateVisitResource(VisitStub visitStub, PatientStub patientResource)
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
    }
}