﻿using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SitAndReachesController : AnalyzablePatientDataController<SitAndReachEntity>
    {
        public SitAndReachesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IActionResult Interpret(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Classify(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}