using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService
{
    public interface IClassificationService<TClassifier, TClassification> 
        where TClassifier : class, IClassifiable<TClassification>, new()
        where TClassification : class
    {
        ClassificationService<TClassifier, TClassification> InitializeWith(int id);
        TClassification Classify { get; }
    }
}