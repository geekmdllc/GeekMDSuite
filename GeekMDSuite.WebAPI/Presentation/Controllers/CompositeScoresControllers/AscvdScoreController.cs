using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.CompositeScoresControllers
{
    [Produces("application/json", "application/xml")]
    public class AscvdScoreController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public AscvdScoreController(IClassificationRepository classifications)
        {
            _classifications = classifications;
        }

        [HttpGet]
        [Route("example/")]
        public IActionResult GetExample()
        {
            var bp = BloodPressure.Build(115, 69);
            var hdl = Quantitative.Serum.HighDensityLipoprotein(60);
            var ldl = Quantitative.Serum.LowDensityLipoprotein(95);
            var total = Quantitative.Serum.CholesterolTotal(160);
            var patient = PatientBuilder.Initialize()
                .SetDateOfBirth(1990, 1, 1)
                .SetGender(GenderIdentity.Female)
                .SetMedicalRecordNumber("132121234")
                .SetName("Test", "Patient")
                .SetRace(Race.Latin)
                .AddComorbidity(ChronicDisease.Diabetes)
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

        [HttpPost]
        public IActionResult Post([FromBody] AscvdParameters parameters)
        {
            return Ok(new AscvdClassification(parameters).Classification);
        }
    }
}