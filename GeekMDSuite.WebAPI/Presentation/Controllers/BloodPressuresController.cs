using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BloodPressuresController : EntityDataController<BloodPressureEntity>
    {
        public BloodPressuresController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        // GET api/bloodPressures/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var found = UnitOfWork.BloodPressures.FindById(id);
            if (found == null) return NotFound();

            var interp = new BloodPressureClassification(found);
            
            return Ok(interp.Classification);
        }
        
        // GET api/bloodPressures/classify/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            var found = UnitOfWork.BloodPressures.FindById(id);
            if (found == null) return NotFound();

            var interp = new BloodPressureInterpretation(found);
            
            return Ok(interp.Interpretation);
        }

    }
}