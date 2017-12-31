using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class SpirometriesRepository : RepositoryAssociatedWithVisit<SpirometryEntity>, ISpirometriesRepository
    {
        public SpirometriesRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}