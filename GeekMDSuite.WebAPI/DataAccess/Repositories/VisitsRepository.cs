using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class VisitsRepository : RepositoryAssociatedWithVisit<VisitEntity>, IVisitsRepository
    {
        public VisitsRepository(GeekMdSuiteDbContext context) : base (context) { }
     }
}