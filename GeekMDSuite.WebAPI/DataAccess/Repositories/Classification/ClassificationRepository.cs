using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService.CompositeScores;
using GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.Classification
{
    public class ClassificationRepository : IClassificationRepository
    {
        public ClassificationRepository(IUnitOfWork unitOfWork)
        {
            AscvdScores = new AscvdClassificationService(unitOfWork);
            Audiograms = new AudiogramClassificationService(unitOfWork);
            BloodPressures = new BloodPressureClassificationService(unitOfWork);
            BodyCompositions = new BodyCompositionClassificationService(unitOfWork);
            CarotidUltrasounds = new CarotidUltrasoundClassificationService(unitOfWork);
        }

        public IAscvdClassificationService AscvdScores { get; set; }
        public IAudiogramClassificationService Audiograms { get; set; }
        public IBloodPressureClassificationService BloodPressures { get; set; }
        public IBodyCompositionClassificationService BodyCompositions { get; set; }
        public ICarotidUltrasoundClassificationService CarotidUltrasounds { get; set; }
    }
}