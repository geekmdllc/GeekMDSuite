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
    public class CarotidUltrasoundsController : Controller
    {
        public CarotidUltrasoundsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        private readonly IUnitOfWork _unitOfWork;
        
        // GET api/carotidultrasounds
        [HttpGet]
        public IEnumerable<CarotidUltrasoundEntity> Get()
        {
            return _unitOfWork.CarotidUltrasounds.All();
        }
        
        // GET api/carotidultrasounds/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.CarotidUltrasounds.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/carotidultrasounds
        [HttpPost]
        public void Post([FromBody] CarotidUltrasoundEntity carotidUltrasound)
        {
            _unitOfWork.CarotidUltrasounds.Add(carotidUltrasound);
            _unitOfWork.Complete();
        }
        
        // PUT api/carotidultrasounds/
        [HttpPut]
        public ActionResult Put([FromBody] CarotidUltrasoundEntity carotidUltrasound)
        {
            try
            {
                _unitOfWork.CarotidUltrasounds.Update(carotidUltrasound);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/carotidultrasounds/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.CarotidUltrasounds.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/carotidultrasounds --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.CarotidUltrasounds.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // GET api/carotidultrasounds/classify/5
        [HttpGet]
        [Route("classify/{id}")]
        public IActionResult Classify(int id)
        {
            var cbp = _unitOfWork.CarotidUltrasounds.FindById(id);
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
