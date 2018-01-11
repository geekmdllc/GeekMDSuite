using System;
using System.IO;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public class VisitController : VisitDataController<VisitEntity>
    {
        private readonly INewVisitService _newVisitService;

        public VisitController(IUnitOfWork unitOfWork, INewVisitService newVisitService) : base(unitOfWork)
        {
            _newVisitService = newVisitService;
        }

        [HttpGet]
        [Route("{id}")]
        public override async Task<IActionResult> GetByPrimaryKey(int id)
        {
            return NotFound();
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
                return Ok();
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

        public async Task<IActionResult> Search(VisitDataSearchFilter filter)
        {
            return Ok(await UnitOfWork.Visits.Search(filter));
        }
    }
}