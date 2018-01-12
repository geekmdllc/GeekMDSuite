using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class VisitDataControllerTests
    {
        private class FakeVisitDataController : VisitDataController<AudiogramEntity>
        {
            public FakeVisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }
        }
    }
}