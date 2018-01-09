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
                return NotFound();
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
                return NotFound();
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
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult PostToBodyCompositionExpanded([FromBody] BodyCompositionExpandedClassificationParameters bodyComposition)
        {
            try
            {
                return Ok(_classifications.BodyCompositionsExpanded.Classify(bodyComposition));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}