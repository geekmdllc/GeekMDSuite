using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class VisitDataController<TResourceStub> : EntityDataController<TResourceStub> where TResourceStub : class, IVisitData<TResourceStub>, new()
    {
        private readonly IRepositoryAssociatedWithVisitAsync<TResourceStub> _repo;

        protected VisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = UnitOfWork.VisitData<TResourceStub>();
        }
        
        [HttpGet]
        [Route("")]
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

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetByPrimaryKey(int id)
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
    }
}