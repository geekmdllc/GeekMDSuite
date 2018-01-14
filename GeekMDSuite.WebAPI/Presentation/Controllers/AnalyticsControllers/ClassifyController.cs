using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers
{
    [Produces("application/json", "application/xml")]
    public class ClassifyController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public ClassifyController(IClassificationRepository classifications)
        {
            _classifications = classifications;
        }

        public IActionResult PostToAudiogram([FromBody] Audiogram audiogram)
        {
            try
            {
                return Ok(_classifications.Audiograms.Classify(audiogram));
            }
            catch
            {
                return BadRequest(audiogram);
            }
        }

        [HttpPost]
        public IActionResult PostToBloodPressure([FromBody] BloodPressure bloodPressure)
        {
            try
            {
                return Ok(_classifications.BloodPressures.Classify(bloodPressure));
            }
            catch
            {
                return BadRequest(bloodPressure);
            }
        }

        [HttpPost]
        public IActionResult PostToBodyComposition([FromBody] BodyCompositionClassificationParameters bodyComposition)
        {
            try
            {
                return Ok(_classifications.BodyCompositions.Classify(bodyComposition));
            }
            catch
            {
                return BadRequest(bodyComposition);
            }
        }

        [HttpPost]
        public IActionResult PostToBodyCompositionExpanded(
            [FromBody] BodyCompositionExpandedClassificationParameters bodyCompositionExpanded)
        {
            try
            {
                return Ok(_classifications.BodyCompositionsExpanded.Classify(bodyCompositionExpanded));
            }
            catch
            {
                return BadRequest(bodyCompositionExpanded);
            }
        }
    }
}