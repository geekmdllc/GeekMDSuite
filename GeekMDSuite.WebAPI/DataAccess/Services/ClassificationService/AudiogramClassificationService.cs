using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.Core.Tools.Cardiology;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService
{
    public class AudiogramClassificationService : 
        ClassificationService<AudiogramClassification, AudiogramClassificationResult>,
        IAudiogramClassificationService
    {
        public AudiogramClassificationService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        public override ClassificationService<AudiogramClassification, AudiogramClassificationResult> InitializeWith(int id)
        {
            Classifier = new AudiogramClassification(UnitOfWork.Audiograms.FindById(id));
            return this;
        }

    }
}