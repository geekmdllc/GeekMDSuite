using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class TreadmillExerciseStressTestController : AnalyzablePatientDataController<TreadmillExerciseStressTestEntity>
    {
        public TreadmillExerciseStressTestController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Classify(int id)
        {
            throw new NotImplementedException();
        }
    }
}