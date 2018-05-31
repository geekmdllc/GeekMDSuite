using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface
        IPushupsClassificationService : IClassificationService<PushupsClassificationParameters, FitnessClassification>
    {
    }
}