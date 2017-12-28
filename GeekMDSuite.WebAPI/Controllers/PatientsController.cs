using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var patient = PatientBuilder.Initialize()
                .SetDateOfBirth(1983, 6, 29)
                .SetGender(GenderIdentity.Male)
                .SetMedicalRecordNumber("1234567890")
                .SetName("Joe", "Blow")
                .SetRace(Race.White)
                .Build();

            var serializedPatient = JsonConvert.SerializeObject(patient);
            Console.WriteLine(serializedPatient);
            
            var patient2 = PatientBuilder.Initialize()
                .SetDateOfBirth(1905, 3, 13)
                .SetGender(GenderIdentity.Female)
                .SetMedicalRecordNumber("0987654321")
                .SetName("Jane", "Doe")
                .SetRace(Race.BlackOrAfricanAmerican)
                .Build();

            var serializedPatient2 = JsonConvert.SerializeObject(patient2);
            Console.WriteLine(serializedPatient2);

            var list = new List<string>()
            {
                serializedPatient,
                serializedPatient2
            };
            
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}