using System;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class EntityDataController<TEntity,  TResourceStubFromUser> : EntityDataController
        where TEntity : class, IMapProperties<TEntity>, IEntity, new()
    {
        private readonly IRepositoryAsync<TEntity> _repo;

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected EntityDataController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            _repo = UnitOfWork.EntityData<TEntity>();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TResourceStubFromUser obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(obj);
            try
            {
                var entity = Mapper.Map<TResourceStubFromUser, TEntity>(obj);
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
        public async Task<IActionResult> Put([FromBody] TResourceStubFromUser obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(obj);
            try
            {
                var entity = Mapper.Map<TResourceStubFromUser, TEntity>(obj);
                await _repo.Update(entity);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (RepositoryEntityNotFoundException e)
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
            catch (RepositoryEntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}