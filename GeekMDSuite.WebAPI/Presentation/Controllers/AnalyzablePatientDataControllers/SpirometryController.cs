using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class SpirometryController : VisitDataController<SpirometryEntity>
    {
        public SpirometryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}