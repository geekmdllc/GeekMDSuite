using System;
using System.IO;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitsController : VisitDataController<VisitEntity>
    {

        public VisitsController(IUnitOfWork unitOfWork, INewVisitService newVisitService) : base(unitOfWork)
        {
            _newVisitService = newVisitService;
        }

        public override IActionResult Post(VisitEntity visitEntity)
        {
            try
            {
                var newVisit = _newVisitService
                    .WithUnitOfWork(UnitOfWork)
                    .GenerateUsing(visitEntity);

                UnitOfWork.Visits.Add(newVisit);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (InvalidDataException)
            {
                return BadRequest("PatientGuid is empty.");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"{nameof(VisitEntity)} is malformed.");
            }
        }
        
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
            catch (FormatException)
            {
                return BadRequest();
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        private readonly INewVisitService _newVisitService;
    }
}