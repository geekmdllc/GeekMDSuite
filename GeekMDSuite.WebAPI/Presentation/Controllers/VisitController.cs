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
    public class VisitController : EntityDataController<VisitEntity>
    {
        private readonly INewVisitService _newVisitService;
        private readonly IMapper _mapper;

        public VisitController(IUnitOfWork unitOfWork, INewVisitService newVisitService, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
            _newVisitService = newVisitService;
        }
        
        public async Task<IActionResult> Search(VisitDataSearchFilter filter)
        {
            return Ok(await UnitOfWork.Visits.Search(filter));
        }
        
        public async Task<IActionResult> GetByVisitGuid(Guid guid)
        {
            try
            {
                var visitEntity = await UnitOfWork.Visits.FindByGuid(guid);
                var visit = _mapper.Map<VisitEntity, VisitStub>(visitEntity);
                
                var patientEntity = await UnitOfWork.Patients.FindByGuid(visitEntity.PatientGuid);
                var patient = _mapper.Map<PatientEntity, PatientStub>(patientEntity);
                
                var links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Rel = UrlRelationship.Self, 
                        Href = "localhost"
                    },
                    new ResourceLink
                    {
                        Rel = UrlRelationship.Child,
                        Href = "localhost/child"
                    }
                };

                return Ok(new VisitResourceModel
                {
                    Visit = visit,
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

        public override async Task<IActionResult> Post([FromBody] VisitEntity visitEntity)
        {
            try
            {
                var newVisit = await _newVisitService
                    .WithUnitOfWork(UnitOfWork)
                    .UsingTemplatePatient(visitEntity);

                await UnitOfWork.Visits.Add(newVisit);
                await UnitOfWork.Complete();
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

    }
}