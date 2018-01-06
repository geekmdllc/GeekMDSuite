using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class VisitDataController<T> : EntityDataController<T> where T : class, IVisitData<T>
    {
        private readonly IRepositoryAssociatedWithVisit<T> _repo;

        protected VisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = UnitOfWork.VisitData<T>();
        }

        [HttpGet("byvisit/{guid}")]
        public IActionResult GetByVisitGuid(Guid guid)
        {
            try
            {
                return Ok(_repo.FindByVisit(guid));
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
        public IActionResult GetByPatientGuid(Guid guid)
        {
            try
            {
                return Ok(_repo.FindByPatientGuid(guid));
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