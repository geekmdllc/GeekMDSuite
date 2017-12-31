using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FunctionalMovementScreensController : VisitDataController<FunctionalMovementScreenEntity>
    {
        public FunctionalMovementScreensController(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        // GET api/functionalmovementscreens/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var found = UnitOfWork.FunctionalMovementScreens.FindById(id);
            if (found == null) return NotFound();

            var fmsInterp = new FunctionalMovementScreenClassification(found);
            
            return Ok(fmsInterp.Classification);
        }
        
        // GET api/functionalmovementscreens/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }
    }
}