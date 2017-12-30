using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class CentralBloodPressuresRepository : Repository<CentralBloodPressureEntity>, ICentralBloodPressureRepository
    {
        public CentralBloodPressuresRepository( GeekMdSuiteDbContext context) : base (context)
        {
            
        }
        
    }
}