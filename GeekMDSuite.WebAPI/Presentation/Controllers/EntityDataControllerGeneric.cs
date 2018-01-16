using System;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class EntityDataController<TEntity,  TResourceStubFromUser> : EntityDataController
        where TEntity : class, IMapProperties<TEntity>, IEntity, new()
        where TResourceStubFromUser : class, IVisitData, new()
    {
        private readonly IRepositoryAsync<TEntity> _repo;

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        private readonly IErrorService _errorService;

        protected EntityDataController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService)
        {
            UnitOfWork = unitOfWork;
            _repo = UnitOfWork.EntityData<TEntity>();
            _errorService = errorService;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TResourceStubFromUser obj)
        {
            const string badInput = "The object could not created because it was not properly formatted";
            if (!ModelState.IsValid)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The object provided from the user was invalid. The resource was therefore not added.")
                    .TellsUser(badInput)
                    .Build();
                return BadRequest(error);
            }
            try
            {
                var entity = Mapper.Map<TResourceStubFromUser, TEntity>(obj);
                await _repo.Add(entity);
                await UnitOfWork.Complete();
                return Ok();
            }
            catch (EntityNotUniqeException e)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.EntityIdIsNotUniqe)
                    .HasInternalMessage($"The entity id {obj.Id} is not unique in the repository. The resource could not be added.")
                    .TellsUser("The identifier for this entity already exists in the database and it cannot be added with a non-unique identifier")
                    .Build();
                return Conflict(error);
            }
            catch (ArgumentNullException)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The object from user was received as a null object. No resource was created.")
                    .TellsUser(badInput)
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TResourceStubFromUser obj)
        {
            if (!ModelState.IsValid)
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("The object was received with invalid model state. It could not be updated.")
                    .TellsUser("The object was recieved imprpoerly formatted and cannot be updated")
                    .Build();
                return BadRequest(error);
            }
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