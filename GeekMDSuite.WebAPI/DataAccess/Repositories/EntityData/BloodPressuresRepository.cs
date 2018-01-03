using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class BloodPressuresRepository : RepositoryAssociatedWithVisit<BloodPressureEntity>, IBloodPressuresRepository
    {
        public BloodPressuresRepository(GeekMdSuiteDbContext context) : base (context) {}
    }
}