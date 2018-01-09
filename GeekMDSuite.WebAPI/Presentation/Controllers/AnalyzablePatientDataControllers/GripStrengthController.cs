using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class GripStrengthController : VisitDataController<GripStrengthEntity>
    {
        public GripStrengthController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}