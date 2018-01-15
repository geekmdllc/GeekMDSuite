using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    public abstract class EntityDataController : Controller
    {
        public ConflictResult Conflict(object obj)
        {
            return new ConflictResult(obj);
        }
    }
}