using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface
        ISitAndReachClassificationService : IClassificationService<SitAndReachClassificationParameters,
            FitnessClassification>
    {
    }
}