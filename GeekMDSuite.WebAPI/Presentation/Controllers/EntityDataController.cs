using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
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
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.All());
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.FindById(id));
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            try
            {
                _repo.Add(entity);
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
        
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            try
            {
                _repo.Update(entity);
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
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpDelete]
        public IActionResult Delete([FromBody] int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    _repo.Delete(id);
                }
                UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
        
        public ConflictResult Conflict() => new ConflictResult();

        protected EntityDataController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repo = UnitOfWork.EntityData<T>();
        }
        
        protected readonly IUnitOfWork UnitOfWork;

        private readonly IRepository<T> _repo;
    }
}