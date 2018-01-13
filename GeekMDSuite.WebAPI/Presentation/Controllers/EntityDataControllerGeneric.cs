using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class EntityDataController<TResourceStub> : EntityDataController where TResourceStub : class, IEntity<TResourceStub>, new()
    {
        private readonly IRepositoryAsync<TResourceStub> _repo;

        protected readonly IUnitOfWork UnitOfWork;

        protected EntityDataController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repo = UnitOfWork.EntityData<TResourceStub>();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TResourceStub entity)
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
        public async Task<IActionResult> Put([FromBody] TResourceStub entity)
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

        [HttpDelete]
        [Route("{id}")]
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

    }
}