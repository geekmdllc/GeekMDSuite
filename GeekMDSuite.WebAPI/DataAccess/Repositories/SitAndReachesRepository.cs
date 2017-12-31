using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class SitAndReachesRepository : RepositoryAssociatedWithVisit<SitAndReachEntity>, ISitAndReachesRepository
    {
        public SitAndReachesRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}