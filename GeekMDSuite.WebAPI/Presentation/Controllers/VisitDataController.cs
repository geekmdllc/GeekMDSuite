using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
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
        // GET api/visits/bypatient/"guid"
        [HttpGet("byvisit/{guid}")]
        public IActionResult GetByVisit(Guid guid)
        {
            var found = UnitOfWork.VisitDataRepository<T>().FindByVisit(guid);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        // GET api/visits/bypatient/"guid"
        [HttpGet("bypatient/{guid}")]
        public IActionResult GetByPatientGuid(Guid guid)
        {
            var found = UnitOfWork.VisitDataRepository<T>().FindByPatient(guid);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
    }
}