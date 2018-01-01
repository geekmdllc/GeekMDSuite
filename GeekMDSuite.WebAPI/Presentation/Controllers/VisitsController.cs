using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitsController : VisitDataController<VisitEntity>
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
        
        // GET api/visits/byname
        [HttpGet("byname/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var result = UnitOfWork.Visits.FindByName(name);
                return Ok(result);
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
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