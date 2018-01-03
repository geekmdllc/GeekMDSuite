using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class CarotidUltrasoundClassificationService
        : ClassificationService<CarotidUltrasoundClassification, CarotidUltrasoundClassificationResult>,
            ICarotidUltrasoundClassificationService
    {
        public CarotidUltrasoundClassificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override ClassificationService<CarotidUltrasoundClassification, CarotidUltrasoundClassificationResult> InitializeWith(int id)
        {
            Classifier = new CarotidUltrasoundClassification(UnitOfWork.CarotidUltrasounds.FindById(id));
            return this;
        }
    }
}