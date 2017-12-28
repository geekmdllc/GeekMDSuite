using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.TestRepositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientsController : Controller
    {
        private readonly IPatientRepo _testPatientRepo;

        public PatientsController(IPatientRepo testPatientRepo)
        {
            _testPatientRepo = testPatientRepo;
        }
        // GET api/patients
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _testPatientRepo.All;
        }

        // GET api/patients/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return _testPatientRepo.All.ElementAt(id);
        }

        // POST api/patients
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/patients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/patients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Removing element at {id}.");
        }
        
        
    }
}