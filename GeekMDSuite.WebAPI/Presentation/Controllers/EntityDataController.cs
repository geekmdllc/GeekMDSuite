using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class EntityDataController<T> : Controller where T : class, IEntity<T>
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected EntityDataController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        // GET api/T
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return UnitOfWork.EntityDataRepository<T>().All();
        }
        
        // GET api/T/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = UnitOfWork.EntityDataRepository<T>().FindById(id);
            if (found == null) return NotFound();
            
            return Ok(found);
        }
        
        // POST api/T/
        [HttpPost]
        public void Post([FromBody] T entity)
        {
            UnitOfWork.EntityDataRepository<T>().Add(entity);
            UnitOfWork.Complete();
        }
        
        // PUT api/T/
        [HttpPut]
        public ActionResult Put([FromBody] T entity)
        {
            try
            {
                UnitOfWork.EntityDataRepository<T>().Update(entity);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE api/T/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                UnitOfWork.EntityDataRepository<T>().Delete(id);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // DELETE/api/T --> from body [1,2,3,...,n]
        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    UnitOfWork.EntityDataRepository<T>().Delete(id);
                }
                UnitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}