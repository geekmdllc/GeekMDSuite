using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class CarotidUltrasoundsRepository : Repository<CarotidUltrasoundEntity>, ICarotidUltrasoundsRepository
    {
        public CarotidUltrasoundsRepository(GeekMdSuiteDbContext context) : base(context)
        {
            
        }
    }
}