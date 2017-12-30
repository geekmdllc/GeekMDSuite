using GeekMDSuite.WebAPI.Core.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    public class BloodPressuresController : Controller
    {
        public BloodPressuresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        private readonly IUnitOfWork _unitOfWork;
    }
}