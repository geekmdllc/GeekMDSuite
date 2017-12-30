using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class CentralBloodPressuresRepository : RepositoryAssociatedWithVisit<CentralBloodPressureEntity>, ICentralBloodPressureRepository
    {
        public CentralBloodPressuresRepository( GeekMdSuiteDbContext context) : base (context)
        {
            
        }
        
    }
}