using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientsController : EntityDataController<PatientEntity>
    {
        public PatientsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        // GET api/patients/joe
        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var found = UnitOfWork.Patients.FindByName(name);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/mrn/joe
        [HttpGet]
        [Route("mrn/{mrn}")]
        public IActionResult GetByMrn(string mrn)
        {
            var found = UnitOfWork.Patients.FindByMedicalRecordNumber(mrn);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/guid/guid
        [HttpGet]
        [Route("guid/{guid}")]
        public IActionResult GetByMrn(Guid guid)
        {
            var found = UnitOfWork.Patients.FindByGuid(guid);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
    }
}