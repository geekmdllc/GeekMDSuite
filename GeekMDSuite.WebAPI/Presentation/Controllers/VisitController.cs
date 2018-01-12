using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public class VisitController : EntityDataController<VisitEntity>
    {
        private readonly INewVisitService _newVisitService;

        public VisitController(IUnitOfWork unitOfWork, INewVisitService newVisitService) : base(unitOfWork)
        {
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
                var visit = (await UnitOfWork.Visits.FindByVisit(guid)).FirstOrDefault();
                if (visit == null)
                    throw new ArgumentNullException(nameof(visit));
                var patient = await UnitOfWork.Patients.FindByGuid(visit.PatientGuid);
                return Ok(new VisitResourceModel(visit, patient));
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