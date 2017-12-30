using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
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
            var cbpe = new CentralBloodPressureEntity(CentralBloodPressureBuilder.Initialize()
                .SetAugmentedIndex(33)
                .SetAugmentedPressure(8)
                .SetCentralSystolicPressure(132)
                .SetPulsePressure(44)
                .SetPulseWaveVelocity(7.9)
                .SetReferenceAge(44)
                .Build());
            
            // return _unitOfWork.CentralBloodPressures.All();
            return new[] {cbpe, cbpe, cbpe};
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
        public void Post([FromBody] CentralBloodPressureEntity audiogram)
        {
            _unitOfWork.CentralBloodPressures.Add(audiogram);
            _unitOfWork.Complete();
        }
        
        // PUT api/centralbloodpressures/
        [HttpPut]
        public ActionResult Put([FromBody] CentralBloodPressureEntity audiogram)
        {
            try
            {
                _unitOfWork.CentralBloodPressures.Update(audiogram);
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
        
        private readonly IUnitOfWork _unitOfWork;
    }
}