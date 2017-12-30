using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientsController : Controller
    {
        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/patients
        [HttpGet]
        public IEnumerable<PatientEntity> Get()
        {
            return _unitOfWork.Patients.All();
        }

        // GET api/patients/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.Patients.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/joe
        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var found = _unitOfWork.Patients.FindByName(name);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/joe
        [HttpGet]
        [Route("mrn/{mrn}")]
        public IActionResult GetByMrn(string mrn)
        {
            var found = _unitOfWork.Patients.FindByMedicalRecordNumber(mrn);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }

        // POST api/patients
        [HttpPost]
        public void Post([FromBody] PatientEntity patient)
        {
            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Complete();
        }

        // PUT api/patients/
        [HttpPut]
        public ActionResult Put([FromBody] PatientEntity patient)
        {
            try
            {
                _unitOfWork.Patients.Update(patient);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE api/patients/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.Patients.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/patients --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.Patients.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        private readonly IUnitOfWork _unitOfWork;

    }
}