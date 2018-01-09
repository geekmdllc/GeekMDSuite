using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public class PatientController : EntityDataController<PatientEntity>
    {
        private readonly INewPatientService _newPatientService;

        public PatientController(IUnitOfWork unitOfWork, INewPatientService newPatientService) : base(unitOfWork)
        {
            _newPatientService = newPatientService;
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] PatientEntity patient)
        {
            try
            {
                var newPatient = await _newPatientService
                    .WithUnitOfWork(UnitOfWork)
                    .GenerateUsing(patient);
                
                await UnitOfWork.Patients.Add(newPatient);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (MedicalRecordAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                return Ok(await UnitOfWork.Patients.FindByName(name));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A null string was provided in place of a name.");
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpGet]
        [Route("mrn/{mrn}")]
        public async Task<IActionResult> GetByMrn(string mrn)
        {
            try
            {
                return Ok(await UnitOfWork.Patients.FindByMedicalRecordNumber(mrn));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A null string was provided in place of a medical record number.");
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/patients/guid/guid
        [HttpGet]
        [Route("guid/{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            try
            {
                return Ok(await UnitOfWork.Patients.FindByGuid(guid));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("An empty Guid was provided.");
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/patients/bydob/1.1.1900
        [HttpGet("bydob/{dateOfBirth}")]
        public async Task<IActionResult> GetByDateOfBirth(string dateOfBirth)
        {
            try
            {
                var parsedDob = DateTime.Parse(dateOfBirth);
                return Ok(await UnitOfWork.Patients.FindByDateOfBirth(parsedDob));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest($"{dateOfBirth} is out of range the allowable dates of birth.");
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}