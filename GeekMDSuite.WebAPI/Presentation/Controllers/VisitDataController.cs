using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class VisitDataController<T> : EntityDataController<T> where T : class, IVisitData<T>
    {
        protected VisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        [HttpGet("byvisit/{guid}")]
        public IActionResult GetByVisitGuid(Guid guid)
        {
            try
            {
                var result = UnitOfWork.VisitData<T>().FindByVisit(guid);
                return Ok(result);
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
        public virtual IActionResult GetByPatientGuid(Guid guid)
        {
            try
            {
                var result = UnitOfWork.VisitData<T>().FindByPatientGuid(guid);
                return Ok(result);
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