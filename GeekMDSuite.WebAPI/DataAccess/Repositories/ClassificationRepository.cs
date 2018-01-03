using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.DataAccess.Services;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class ClassificationRepository : IClassificationRepository
    {
        public ClassificationRepository(IUnitOfWork unitOfWork)
        {
            Audiograms = new AudiogramClassificationService(unitOfWork);
            BloodPressures = new BloodPressureClassificationService(unitOfWork);
            CarotidUltrasounds = new CarotidUltrasoundClassificationService(unitOfWork);
        }
        public IAudiogramClassificationService Audiograms { get; set; }
        public IBloodPressureClassificationService BloodPressures { get; set; }
        public ICarotidUltrasoundClassificationService CarotidUltrasounds { get; set; }
    }
}