using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class OccularPressuresRepository : RepositoryAssociatedWithVisit<OcularPressureEntity>, IOccularPressuresRepository
    {
        public OccularPressuresRepository(GeekMdSuiteDbContext context) : base(context) {}
    }
}