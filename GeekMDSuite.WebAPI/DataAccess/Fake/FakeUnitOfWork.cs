namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public class FakeUnitOfWork : UnitOfWork
    {
        public FakeUnitOfWork() : base(FakeGeekMdSuiteContextBuilder.Context)
        {
        }
    }
}