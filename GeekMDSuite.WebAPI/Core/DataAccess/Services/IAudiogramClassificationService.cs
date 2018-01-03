using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface IAudiogramClassificationService 
        : IClassificationService<AudiogramClassification, AudiogramClassificationResult>
    {
        
    }
}