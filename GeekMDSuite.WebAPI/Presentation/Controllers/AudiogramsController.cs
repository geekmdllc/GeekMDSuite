using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AudiogramsController : EntityDataController<AudiogramEntity>
    {
        public AudiogramsController(IUnitOfWork unitOfWork) : base(unitOfWork){ }
        
        // GET api/audiograms/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var found = UnitOfWork.Audiograms.FindById(id);
            if (found == null) return NotFound();

            var interp = new AudiogramClassification(found);
            
            return Ok(interp.Classification);
        }
        
        // GET api/audiograms/interpret/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }
    }
}