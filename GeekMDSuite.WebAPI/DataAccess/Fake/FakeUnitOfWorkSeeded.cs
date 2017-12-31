using GeekMDSuite.WebAPI.DataAccess.Context;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public class FakeUnitOfWorkSeeded : UnitOfWork
    {
        public FakeUnitOfWorkSeeded() : base(FakeGeekMdSuiteContextBuilder.Context)
        {
        }
    }
}