using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BloodPressuresController : AnalyzablePatientDataController<BloodPressureEntity>
    {
        private readonly IClassificationRepository _classifications;

        public BloodPressuresController(IUnitOfWork unitOfWork, IClassificationRepository classifications) : base(unitOfWork)
        {
            _classifications = classifications;
        }

        public override IActionResult Interpret(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Classify(int id)
        {
            try
            {
                return Ok(_classifications.BloodPressures.InitializeWith(id).Classify);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}