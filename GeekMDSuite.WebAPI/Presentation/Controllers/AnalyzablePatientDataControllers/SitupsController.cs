using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class SitupsController : VisitDataController<SitupsEntity>
    {
        public SitupsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}