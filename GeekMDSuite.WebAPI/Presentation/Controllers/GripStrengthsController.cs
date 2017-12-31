using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GripStrengthsController : Controller
    {
        public GripStrengthsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/gripstrengths
        [HttpGet]
        public IEnumerable<GripStrengthEntity> Get()
        {
           return _unitOfWork.GripStrengths.All();
        }
        
        // GET api/gripstrengths/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.GripStrengths.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/gripstrengths/
        [HttpPost]
        public void Post([FromBody] GripStrengthEntity gripStrengths)
        {
            _unitOfWork.GripStrengths.Add(gripStrengths);
            _unitOfWork.Complete();
        }
        
        // PUT api/gripstrengths/
        [HttpPut]
        public ActionResult Put([FromBody] GripStrengthEntity gripStrengths)
        {
            try
            {
                _unitOfWork.GripStrengths.Update(gripStrengths);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/gripstrengths/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.GripStrengths.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/gripstrengths --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.GripStrengths.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
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
        
        private readonly IUnitOfWork _unitOfWork;
    }
}