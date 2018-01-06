using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        private readonly IUnitOfWork _unitOfWorkEmpty = new FakeUnitOfWorkEmpty();
        private readonly IUnitOfWork _unitOfWorkSeeded = new FakeUnitOfWorkSeeded();
    }
}