using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CentralBloodPressuresController : Controller
    {
        public CentralBloodPressuresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/centralbloodpressures
        [HttpGet]
        public IEnumerable<CentralBloodPressureEntity> Get()
        {
             return _unitOfWork.CentralBloodPressures.All();
        }
        
        // GET api/centralbloodpressures/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.CentralBloodPressures.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/centralbloodpressures/
        [HttpPost]
        public void Post([FromBody] CentralBloodPressureEntity centralBloodPressure)
        {
            _unitOfWork.CentralBloodPressures.Add(centralBloodPressure);
            _unitOfWork.Complete();
        }
        
        // PUT api/centralbloodpressures/
        [HttpPut]
        public ActionResult Put([FromBody] CentralBloodPressureEntity centralBloodPressure)
        {
            try
            {
                _unitOfWork.CentralBloodPressures.Update(centralBloodPressure);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/centralbloodpressures/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.CentralBloodPressures.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/centralbloodpressures --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.CentralBloodPressures.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // GET api/centralbloodpressures/classify/5
        [HttpGet]
        [Route("interpret/{id}")]
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
        
        private readonly IUnitOfWork _unitOfWork;
    }
}