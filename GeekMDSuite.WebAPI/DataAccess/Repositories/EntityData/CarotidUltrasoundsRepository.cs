using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class CarotidUltrasoundsRepository : RepositoryAssociatedWithVisit<CarotidUltrasoundEntity>, ICarotidUltrasoundsRepository
    {
        public CarotidUltrasoundsRepository(GeekMdSuiteDbContext context) : base(context)
        {
            
        }
    }
}