using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FunctionalMovementScreensController : Controller
    {
        public FunctionalMovementScreensController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/functionalmovementscreens
        [HttpGet]
        public IEnumerable<FunctionalMovementScreenEntity> Get()
        {
            return _unitOfWork.FunctionalMovementScreens.All();
        }
        
        // GET api/centralbloodpressures/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.FunctionalMovementScreens.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/centralbloodpressures/
        [HttpPost]
        public void Post([FromBody] FunctionalMovementScreenEntity functionalMovementScreen)
        {
            _unitOfWork.FunctionalMovementScreens.Add(functionalMovementScreen);
            _unitOfWork.Complete();
        }
        
        // PUT api/centralbloodpressures/
        [HttpPut]
        public ActionResult Put([FromBody] FunctionalMovementScreenEntity functionalMovementScreen)
        {
            try
            {
                _unitOfWork.FunctionalMovementScreens.Update(functionalMovementScreen);
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
                _unitOfWork.FunctionalMovementScreens.Delete(id);
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
                    _unitOfWork.FunctionalMovementScreens.Delete(id);
                }
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        private readonly IUnitOfWork _unitOfWork;
    }
}