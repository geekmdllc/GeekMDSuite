using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class VisitDataController<T> : EntityDataController<T> where T : class, IVisitData<T>
    {
        private readonly IRepositoryAssociatedWithVisitAsync<T> _repo;

        protected VisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = UnitOfWork.VisitData<T>();
        }

        public async Task<IActionResult> GetByVisitGuid(Guid guid)
        {
            try
            {
                return Ok(await _repo.FindByVisit(guid));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("An emtpy Guid was provided.");
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}