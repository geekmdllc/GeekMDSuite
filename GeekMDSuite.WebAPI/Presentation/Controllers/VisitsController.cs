using System;
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
        
        // GET api/visits/bymrn/"guid"
        [HttpGet("bymrn/{mrn}")]
        public IActionResult GetByMedicalRecordNumber(string mrn)
        {
            try
            {
                return Ok(UnitOfWork.Visits.FindByMedicalRecordNumber(mrn));
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        // GET api/visits/byname
        [HttpGet("byname/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(UnitOfWork.Visits.FindByName(name));
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
            try
            {
                var parsedDob = DateTime.Parse(dateOfBirth);
                return Ok(UnitOfWork.Visits.FindByDateOfBirth(parsedDob));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}