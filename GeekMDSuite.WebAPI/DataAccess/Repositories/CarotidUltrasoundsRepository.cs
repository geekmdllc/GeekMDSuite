using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Persistence;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class CarotidUltrasoundsRepository : Repository<CarotidUltrasoundEntity>, ICarotidUltrasoundsRepository
    {
        public CarotidUltrasoundsRepository(GeekMdSuiteDbContext context) : base(context)
        {
            
        }
    }
}