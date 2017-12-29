using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AudiogramsController : Controller
    {
        public AudiogramsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/audiograms
        [HttpGet]
        public IEnumerable<AudiogramEntity> Get()
        {
           return _unitOfWork.Audiograms.All();
        }
        
        // GET api/audiograms/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _unitOfWork.Audiograms.FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/audiograms/
        [HttpPost]
        public void Post([FromBody] AudiogramEntity audiogram)
        {
            _unitOfWork.Audiograms.Add(audiogram);
            _unitOfWork.Complete();
        }
        
        // PUT api/audiograms/
        [HttpPut]
        public ActionResult Put([FromBody] AudiogramEntity audiogram)
        {
            try
            {
                _unitOfWork.Audiograms.Update(audiogram);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/audiograms/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.Audiograms.Delete(id);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/audiograms --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _unitOfWork.Audiograms.Delete(id);
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