using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class EntityDataController<T> : Controller where T : class, IEntity<T>
    {
        private readonly IRepository<T> _repo;

        protected readonly IUnitOfWork UnitOfWork;

        protected EntityDataController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repo = UnitOfWork.EntityData<T>();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repo.All());
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPrimaryKey(int id)
        {
            try
            {
                return Ok(await _repo.FindById(id));
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound($"Cannot locate element with id {id}.");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            try
            {
                await _repo.Add(entity);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (EntityNotUniqeException e)
            {
                return Conflict(e.Message);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A null entity was provided.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            try
            {
                await _repo.Update(entity);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A null entity was provided.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.Delete(id);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        //TODO: Remove this method
        public async Task<IActionResult> Delete([FromBody] int[] ids)
        {
            if (ids == null || ids.Length <= 0)
                return new BadRequestResult();

            try
            {
                foreach (var id in ids) await _repo.Delete(id);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryElementNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        public ConflictResult Conflict(string message)
        {
            return new ConflictResult(message);
        }
    }
}