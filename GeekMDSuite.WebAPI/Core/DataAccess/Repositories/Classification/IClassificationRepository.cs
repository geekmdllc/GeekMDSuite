using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService.CompositeScores;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification
{
    public interface IClassificationRepository
    {
        IAscvdClassificationService AscvdScores { get; }
        IAudiogramClassificationService Audiograms { get; }
        IBloodPressureClassificationService BloodPressures { get; }
        IBodyCompositionClassificationService BodyCompositions { get; }
        ICarotidUltrasoundClassificationService CarotidUltrasounds { get; }
    }
}