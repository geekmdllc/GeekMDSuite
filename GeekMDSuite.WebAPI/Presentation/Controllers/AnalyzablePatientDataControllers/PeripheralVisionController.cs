using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class PeripheralVisionController : VisitDataController<PeripheralVisionEntity>
    {
        public PeripheralVisionController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}