using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
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

        public async Task<IActionResult> Search(PatientDataSearchFilter filter)
        {
            return Ok(await UnitOfWork.Patients.Search(filter));
        }

        public override async Task<IActionResult> Post([FromBody] PatientEntity patient)
        {
            try
            {
                var newPatient = await _newPatientService
                    .WithUnitOfWork(UnitOfWork)
                    .UsingTemplatePatient(patient);
                
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
                
        public async Task<IActionResult> GetVisits(Guid guid)
        {                      
            var patient = await UnitOfWork.Patients.FindByGuid(guid);
            return Ok((await UnitOfWork.Visits.All()).Where( v => v.PatientGuid == guid));
        }

    }
}