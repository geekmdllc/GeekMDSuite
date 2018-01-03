using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface ICarotidUltrasoundClassificationService
        : IClassificationService<CarotidUltrasoundClassification, CarotidUltrasoundClassificationResult>
    {
        
    }
}