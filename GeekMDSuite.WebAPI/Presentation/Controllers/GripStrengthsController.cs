using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GripStrengthsController : EntityDataController<GripStrengthEntity>
    {
        public GripStrengthsController(IUnitOfWork unitOfWork) : base(unitOfWork) {}
        
        // GET api/gripstrengths/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            throw new NotImplementedException();
        }
        
        // GET api/gripstrengths/interpret/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }
    }
}