using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class BloodPressureController : AnalyzablePatientDataController<BloodPressureEntity>
    {
        private readonly IClassificationRepository _classifications;

        public BloodPressureController(IUnitOfWork unitOfWork, IClassificationRepository classifications) :
            base(unitOfWork)
        {
            _classifications = classifications;
        }

        public override IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
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