using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CarotidUltrasoundsController : VisitDataController<CarotidUltrasoundEntity>
    {
        public CarotidUltrasoundsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        
        // GET api/carotidultrasounds/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var cbp = UnitOfWork.CarotidUltrasounds.FindById(id);
            if (cbp == null) return NotFound();

            var interp = new CarotidUltrasoundClassification(cbp);
            
            return Ok(interp.Classification);
        }
        
        // GET api/carotidultrasounds/interpret/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }
    }
}
