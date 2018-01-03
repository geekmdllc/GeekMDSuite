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
            var results = UnitOfWork.EntityData<T>().All();
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
                return Ok(UnitOfWork.EntityData<T>().FindById(id));
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        // POST api/T/
        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            try
            {
                UnitOfWork.EntityData<T>().Add(entity);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (EntityNotUniqeException)
            {
                return Conflict();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
        
        // PUT api/T/
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            try
            {
                UnitOfWork.EntityData<T>().Update(entity);
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
        public IActionResult Delete(int id)
        {
            try
            {
                UnitOfWork.EntityData<T>().Delete(id);
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
        public IActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    UnitOfWork.EntityData<T>().Delete(id);
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