using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers
{
    [Produces("application/json", "application/xml")]
    public class ClassifiyController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public ClassifiyController(IClassificationRepository classifications)
        {
            _classifications = classifications;
        }

        [HttpPost]
        [Route("audiogram/")]
        public IActionResult Audiogram([FromBody] Audiogram audiogram)
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
        [Route("bloodpressure")]
        public IActionResult BloodPressure([FromBody] BloodPressure bloodPressure)
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
        [Route("bodycomposition")]
        public IActionResult BodyComposition([FromBody] BodyComposition bodyComposition)
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
    }
}