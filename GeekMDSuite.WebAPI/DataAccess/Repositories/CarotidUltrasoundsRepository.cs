using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
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