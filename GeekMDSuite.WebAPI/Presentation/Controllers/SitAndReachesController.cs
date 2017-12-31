using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SitAndReachesController : EntityDataController<SitAndReachEntity>
    {
        public SitAndReachesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}