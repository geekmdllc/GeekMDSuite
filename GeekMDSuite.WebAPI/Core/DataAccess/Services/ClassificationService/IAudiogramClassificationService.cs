using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService
{
    public interface IAudiogramClassificationService
        : IClassificationService<AudiogramClassification, AudiogramClassificationResult>
    {
    }
}