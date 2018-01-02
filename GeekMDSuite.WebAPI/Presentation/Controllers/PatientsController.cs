using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientsController : EntityDataController<PatientEntity>
    {
        private readonly INewPatientService _newPatientService;
        public PatientsController(IUnitOfWork unitOfWork, INewPatientService newPatientService) : base(unitOfWork)
        {
            _newPatientService = newPatientService;
        }

        [HttpPost]
        public override IActionResult Post([FromBody] PatientEntity patient)
        {
            try
            {
                var newPatient = _newPatientService.GenerateUsing(patient);
                UnitOfWork.Patients.Add(newPatient);
            }
            catch (MedicalRecordNotUniqueException exception)
            {
                Console.WriteLine(exception.Message);
                return Conflict();
            }
            UnitOfWork.Complete();
            return Ok();
        }
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