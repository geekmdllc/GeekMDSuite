using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CentralBloodPressuresController : EntityDataController<CentralBloodPressureEntity>
    {
        public CentralBloodPressuresController(IUnitOfWork unitOfWork) : base(unitOfWork){ }

        // GET api/centralbloodpressures/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            throw new NotImplementedException();
        }
        
        // GET api/centralbloodpressures/interpret/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }
    }
}