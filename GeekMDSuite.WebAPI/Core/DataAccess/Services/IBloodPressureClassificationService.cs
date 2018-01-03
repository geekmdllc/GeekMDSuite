using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface IBloodPressureClassificationService 
        : IClassificationService<BloodPressureClassification, BloodPressureClassificationResult>
    {
        
    }
}