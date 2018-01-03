using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    public abstract class AnalyzablePatientDataController<T> : VisitDataController<T> where T : class, IVisitData<T>
    {
        protected AnalyzablePatientDataController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet("interpret/{id}")]
        public abstract IActionResult Interpret(int id);

        [HttpGet("classify/{id}")]
        public abstract IActionResult Classify(int id);
    }
}