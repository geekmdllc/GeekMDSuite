using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/visits
        [HttpGet]
        public IEnumerable<VisitEntity> Get()
        {
            return _unitOfWork.Visits.All();
        }
        
        // GET api/visits/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.Visits.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/bypatient/"guid"
        [HttpGet("bypatient/{guid}")]
        public IActionResult GetByPatient(Guid guid)
        {
            var found = _unitOfWork.Visits.FindByPatientGuid(guid);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/bymrn/"guid"
        [HttpGet("bymrn/{mrn}")]
        public IActionResult GetByMedicalRecordNumber(string mrn)
        {
            var found = _unitOfWork.Visits.FindByMedicalRecordNumber(mrn);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/byname/"guid"
        [HttpGet("byname/{name}")]
        public IActionResult GetByName(string name)
        {
            var found = _unitOfWork.Visits.FindByName(name);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/visits/bydob/"dateOfBirth"
        [HttpGet("bydob/{dateOfBirth}")]
        public IActionResult GetByDateOfBirth(string dateOfBirth)
        {
            var parsedDob = DateTime.Parse(dateOfBirth);
            var found = _unitOfWork.Visits.FindByDateOfBirth(parsedDob);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/visits/
        [HttpPost]
        public void Post([FromBody] VisitEntity visit)
        {
            _unitOfWork.Visits.Add(visit);
            _unitOfWork.Complete();
        }
        
        // PUT api/visits/
        [HttpPut]
        public ActionResult Put([FromBody] VisitEntity visit)
        {
            try
            {
                _unitOfWork.Visits.Update(visit);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/visits/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.Visits.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/visits --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.Visits.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}