using GeekMDSuite.Core;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;

namespace GeekMDSuite.WebAPI.DataAccess.Services
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