using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification.CompositeScores;
using GeekMDSuite.WebAPI.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.Classification
{
    public class ClassificationRepository : IClassificationRepository
    {
        public ClassificationRepository(IUnitOfWork unitOfWork)
        {
            AscvdScores = new AscvdClassificationService();
            Audiograms = new AudiogramClassificationService();
            BloodPressures = new BloodPressureClassificationService();
            BodyCompositions = new BodyCompositionClassificationService();
            BodyCompositionsExpanded = new BodyCompositionsExpandedClassificationService();
            CarotidUltrasounds = new CarotidUltrasoundClassificationService();
            CardiovascularRegimens = new CardiovascularRegimenClassificationService();
            ResistanceRegimens = new ResistanceRegimenClassificationServiceService();
        }

        public IAscvdClassificationService AscvdScores { get; set; }
        public IAudiogramClassificationService Audiograms { get; set; }
        public IBloodPressureClassificationService BloodPressures { get; set; }
        public IBodyCompositionClassificationService BodyCompositions { get; set; }
        public IBodyCompositionExpandedClassificationService BodyCompositionsExpanded { get; }
        public ICarotidUltrasoundClassificationService CarotidUltrasounds { get; set; }
        public ICardiovascularRegimenClassificationService CardiovascularRegimens { get; set; }
        public IResistanceRegimenClassificationService ResistanceRegimens { get; }
    }
}