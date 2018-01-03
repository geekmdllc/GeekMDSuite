using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService
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