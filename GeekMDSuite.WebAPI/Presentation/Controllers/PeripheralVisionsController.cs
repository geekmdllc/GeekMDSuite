using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PeripheralVisionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeripheralVisionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<PeripheralVisionEntity> Get()
        {
            return _unitOfWork.PeripheralVisions.All();
        }
    }
}