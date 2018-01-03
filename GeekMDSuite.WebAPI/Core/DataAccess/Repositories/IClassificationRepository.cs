using GeekMDSuite.WebAPI.Core.DataAccess.Services;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IClassificationRepository
    {
        IAudiogramClassificationService Audiograms { get; }
        IBloodPressureClassificationService BloodPressures { get; }
        ICarotidUltrasoundClassificationService CarotidUltrasounds { get; }
        
    }
}