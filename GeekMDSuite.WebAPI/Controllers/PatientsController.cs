using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientsController : Controller
    {
        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }
        
        // GET api/patients
        [HttpGet]
        public IEnumerable<PatientEntity> Get()
        {
            return _repository.All();
        }

        // GET api/patients/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _repository.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/joe
        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var found = _repository.FindByName(name);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }
        
        // GET api/patients/joe
        [HttpGet]
        [Route("mrn/{mrn}")]
        public IActionResult GetByMrn(string mrn)
        {
            var found = _repository.FindByMedicalRecordNumber(mrn);
            if (!found.Any()) return NotFound();
            
            return Ok(found);
        }

        // POST api/patients
        [HttpPost]
        public void Post([FromBody] PatientEntity patient)
        {
            _repository.Add(patient);
        }

        // PUT api/patients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/patients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        private readonly IPatientRepository _repository;

    }
}