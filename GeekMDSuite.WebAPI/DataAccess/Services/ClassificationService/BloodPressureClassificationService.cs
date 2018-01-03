using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService
{
    public class BloodPressureClassificationService
        : ClassificationService<BloodPressureClassification, BloodPressureClassificationResult>,
            IBloodPressureClassificationService
    {
        public BloodPressureClassificationService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public override ClassificationService<BloodPressureClassification, BloodPressureClassificationResult> InitializeWith(int id)
        {
            Classifier = new BloodPressureClassification(UnitOfWork.BloodPressures.FindById(id));
            return this;
        }
    }
}