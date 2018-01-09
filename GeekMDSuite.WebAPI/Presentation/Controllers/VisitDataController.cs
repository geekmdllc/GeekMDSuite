using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class VisitDataController<T> : EntityDataController<T> where T : class, IVisitData<T>
    {
        private readonly IRepositoryAssociatedWithVisit<T> _repo;

        protected VisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = UnitOfWork.VisitData<T>();
        }

        [HttpGet("byvisit/{guid}")]
        public async Task<IActionResult> GetByVisitGuid(Guid guid)
        {
            try
            {
                return Ok(await _repo.FindByVisit(guid));
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

        [HttpGet("bypatient/{guid}")]
        public async Task<IActionResult> GetByPatientGuid(Guid guid)
        {
            try
            {
                return Ok(await _repo.FindByPatientGuid(guid));
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
    }
}