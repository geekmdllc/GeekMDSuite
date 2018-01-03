using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.CompositeScoresControllers
{
    [Route("api/compositescores/[controller]")]
    [Produces("application/json")]
    public class AscvdScoreController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public AscvdScoreController(IClassificationRepository classifications)
        {
            _classifications = classifications;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_classifications.AscvdScores.InitializeWith(id).Classify);
        }
    }
}