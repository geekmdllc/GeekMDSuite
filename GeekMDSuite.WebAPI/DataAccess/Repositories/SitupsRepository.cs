using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class SitupsRepository : RepositoryAssociatedWithVisit<SitupsEntity>, ISitupsRepository
    {
        public SitupsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}