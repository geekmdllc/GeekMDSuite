using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IGripStrengthClassificationService
        : IClassificationService<GripStrengthClassificationParameters, GripStrengthClassification>
    {
        
    }
}