using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BloodPressuresController : Controller
    {
        public BloodPressuresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/bloodPressure
        [HttpGet]
        public IEnumerable<BloodPressureEntity> Get()
        {
            return _unitOfWork.BloodPressures.All();
        }
        
        // GET api/bloodPressures/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.BloodPressures.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/bloodPressure
        [HttpPost]
        public void Post([FromBody] BloodPressureEntity bloodPressure)
        {
            _unitOfWork.BloodPressures.Add(bloodPressure);
            _unitOfWork.Complete();
        }
        
        // PUT api/bloodPressures/
        [HttpPut]
        public ActionResult Put([FromBody] BloodPressureEntity bloodPressure)
        {
            try
            {
                _unitOfWork.BloodPressures.Update(bloodPressure);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/bloodPressures/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.BloodPressures.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/bloodPressure --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.BloodPressures.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // GET api/bloodPressures/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var found = _unitOfWork.BloodPressures.FindById(id);
            if (found == null) return NotFound();

            var interp = new BloodPressureClassification(found);
            
            return Ok(interp.Classification);
        }
        
        // GET api/bloodPressures/classify/5
        [HttpGet]
        [Route("interpret/{id}")]
        public IActionResult Interpret(int id)
        {
            var found = _unitOfWork.BloodPressures.FindById(id);
            if (found == null) return NotFound();

            var interp = new BloodPressureInterpretation(found);
            
            return Ok(interp.Interpretation);
        }
        
        private readonly IUnitOfWork _unitOfWork;
    }
}