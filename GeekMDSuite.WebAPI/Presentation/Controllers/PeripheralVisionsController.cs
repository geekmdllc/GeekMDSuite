using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PeripheralVisionsController : VisitDataController<PeripheralVisionEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeripheralVisionsController(IUnitOfWork unitOfWork) : base (unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}