using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class CarotidUltrasoundsRepositoryAsync : RepositoryAssociatedWithVisitAsync<CarotidUltrasoundEntity>,
        ICarotidUltrasoundsRepositoryAsync
    {
        public CarotidUltrasoundsRepositoryAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}