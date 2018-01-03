using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public abstract class ClassificationService<TClassifier, TClassification> 
        : IClassificationService<TClassifier, TClassification> 
        where TClassifier : class, IClassifiable<TClassification>, new()
        where TClassification : class
    {
        protected TClassifier Classifier;
        protected readonly IUnitOfWork UnitOfWork;

        private ClassificationService()
        {
            
        }

        protected ClassificationService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Classifier = new TClassifier();
        }
        public abstract ClassificationService<TClassifier, TClassification> InitializeWith(int id);
        public TClassification Classify => Classifier.Classification;
    }
}