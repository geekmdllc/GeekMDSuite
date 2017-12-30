using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
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
        
        // DELETE/api/patients --> from body [1,2,3,...,n]
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
    }
}
