using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitsController : EntityDataController<VisitEntity>
    {
        public VisitsController(IUnitOfWork unitOfWork) : base(unitOfWork) {}
       
        // GET api/visits/bypatient/"guid"
        [HttpGet("bypatient/{guid}")]
        public IActionResult GetByPatient(Guid guid)
        {
            var found = UnitOfWork.Visits.FindByPatientGuid(guid);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/bymrn/"guid"
        [HttpGet("bymrn/{mrn}")]
        public IActionResult GetByMedicalRecordNumber(string mrn)
        {
            var found = UnitOfWork.Visits.FindByMedicalRecordNumber(mrn);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/byname/"guid"
        [HttpGet("byname/{name}")]
        public IActionResult GetByName(string name)
        {
            var found = UnitOfWork.Visits.FindByName(name);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/bydob/"dateOfBirth"
        [HttpGet("bydob/{dateOfBirth}")]
        public IActionResult GetByDateOfBirth(string dateOfBirth)
        {
            var parsedDob = DateTime.Parse(dateOfBirth);
            var found = UnitOfWork.Visits.FindByDateOfBirth(parsedDob);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
    }
}