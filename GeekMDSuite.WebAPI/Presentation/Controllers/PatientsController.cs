using System;
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
                var newPatient = _newPatientService
                    .WithUnitOfWork(UnitOfWork)
                    .GenerateUsing(patient);
                UnitOfWork.Patients.Add(newPatient);
            }
            catch (MedicalRecordNotUniqueException e)
            {
                Console.WriteLine(e.Message);
                return Conflict();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            UnitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(UnitOfWork.Patients.FindByName(name));
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
        

        [HttpGet]
        [Route("mrn/{mrn}")]
        public IActionResult GetByMrn(string mrn)
        {
            try
            {
                return Ok(UnitOfWork.Patients.FindByMedicalRecordNumber(mrn));
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
        
        // GET api/patients/guid/guid
        [HttpGet]
        [Route("guid/{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            try
            {
                return Ok(UnitOfWork.Patients.FindByGuid(guid));
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