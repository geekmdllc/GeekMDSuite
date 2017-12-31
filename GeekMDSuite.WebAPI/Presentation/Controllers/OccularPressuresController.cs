using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OccularPressuresController : Controller
    {

        public OccularPressuresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<OcularPressureEntity> Get(int id)
        {
            return _unitOfWork.OcularPressures.All();
        }
        private readonly IUnitOfWork _unitOfWork;
    }
}