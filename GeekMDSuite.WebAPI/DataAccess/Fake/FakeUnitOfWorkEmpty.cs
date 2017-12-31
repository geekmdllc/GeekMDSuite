namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public class FakeUnitOfWorkEmpty : UnitOfWork
    {
        public FakeUnitOfWorkEmpty() : base(FakeGeekMdSuiteContextBuilder.EmptyContext)
        {
        }
    }
}