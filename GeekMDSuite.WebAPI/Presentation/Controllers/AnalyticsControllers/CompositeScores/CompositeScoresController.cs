using GeekMDSuite.Analytics.Classification.CompositeScores;
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
    }
}