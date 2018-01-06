using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService
{
    public interface ICarotidUltrasoundClassificationService
        : IClassificationService<CarotidUltrasoundClassification, CarotidUltrasoundClassificationResult>
    {
    }
}