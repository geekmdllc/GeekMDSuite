using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores
{
    [Produces("application/json", "application/xml")]
    public class CompositeScoresController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public CompositeScoresController(IClassificationRepository classifications)
        {
            _classifications = classifications;
        }
       
        [HttpPost]
        [Route("ascvd")]
        public IActionResult AscvdScore([FromBody] AscvdParameters parameters)
        {
            try
            {
                return Ok(new AscvdClassification(parameters).Classification);
            }
            catch
            {
                return BadRequest(parameters);
            }
        }

        [HttpGet]
        [Route("ascvd/example")]
        public IActionResult GetAscvdExample()
        {
            var bp = BloodPressure.Build(155, 90);
            var hdl = Quantitative.Serum.HighDensityLipoprotein(35);
            var ldl = Quantitative.Serum.LowDensityLipoprotein(153);
            var total = Quantitative.Serum.CholesterolTotal(263);
            var patient = PatientBuilder.Initialize()
                .SetDateOfBirth(1990, 1, 1)
                .SetGender(GenderIdentity.Female)
                .SetMedicalRecordNumber("132121234")
                .SetName("Test", "Patient")
                .SetRace(Race.Latin)
                .AddComorbidity(ChronicDisease.Diabetes)
                .AddComorbidity(ChronicDisease.HypertensionTreated)
                .Build();

            var ascvdParameters = AscvdParametersBuilder.Initialize()
                .SetBloodPressure(bp)
                .SetHdlCholesterol(hdl)
                .SetLdlCholesterol(ldl)
                .SetPatient(patient)
                .SetTotalCholesterol(total)
                .Build();

            return Ok(ascvdParameters);
        }
    }
}