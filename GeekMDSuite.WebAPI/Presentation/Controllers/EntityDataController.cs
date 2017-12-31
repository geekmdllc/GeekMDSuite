using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
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

        public ConflictResult Conflict() => new ConflictResult();

        // GET api/T
        [HttpGet]
        public IActionResult Get()
        {
            var results = UnitOfWork.EntityDataRepository<T>().All();
            if (results.Any())
                return Ok(results);
            return NotFound();
        }
        
        // GET api/T/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(UnitOfWork.EntityDataRepository<T>().FindById(id));
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        // POST api/T/
        [HttpPost]
        public virtual ActionResult Post([FromBody] T entity)
        {
            try
            {
                UnitOfWork.EntityDataRepository<T>().Add(entity);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
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
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
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
            catch (RepositoryElementNotFoundException)
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
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}