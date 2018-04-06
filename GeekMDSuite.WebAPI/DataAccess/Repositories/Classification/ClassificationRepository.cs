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
            CentralBloodPressures = new CentralBloodPressureClassificationService();
            FunctionalMovements = new FunctionalMovementScreenClassificationService();
            GripStrengths = new GripStrengthClassificationService();
            IshiharaSixPlateScreens = new IshiharaSixPlateScreenClassificationService();
            OccularPressures = new OccularPressureClassificationService();
            PeripheralVision = new PeripheralVisionClassificationService();
            Pushups = new PushupsClassificationService();
            QualitativeLabs = new QualitativeLabClassificationService();
            QuantitativeLabs = new QuantitativeLabClassificationService();
            ResistanceRegimen = new ResistanceRegimenClassificationService();
            SitAndReach = new SitAndReachClassificationService();
            Situps = new SitupsClassificationService();
            Spirometry = new SpirometryClassificationService();
            Stretching = new StretchingRegimenClassificationService();
            FitTreadmillScore = new FitTreadmillScoreClassificationService();
            VisualAcuity = new VisualAcuityClassificationService();
        }

        public IAscvdClassificationService AscvdScores { get; }
        public IAudiogramClassificationService Audiograms { get; }
        public IBloodPressureClassificationService BloodPressures { get;  }
        public IBodyCompositionClassificationService BodyCompositions { get;  }
        public IBodyCompositionExpandedClassificationService BodyCompositionsExpanded { get; }
        public ICarotidUltrasoundClassificationService CarotidUltrasounds { get;  }
        public ICardiovascularRegimenClassificationService CardiovascularRegimens { get;  }
        public ICentralBloodPressureClassificationService CentralBloodPressures { get;  }
        public IFunctionalMovementClassificationService FunctionalMovements { get;  }
        public IGripStrengthClassificationService GripStrengths { get;  }
        public IIshiharaSixPlateScreenService IshiharaSixPlateScreens { get; }
        public IOccularPressureClassificationService OccularPressures { get;  }
        public IPeripheralVisionClassificationService PeripheralVision { get;  }
        public IPushupsClassificationService Pushups { get; set; }
        public IQualitativeLabsClassificationService QualitativeLabs { get; set; }
        public IQuantitativeLabsClassificationService QuantitativeLabs { get; set; }
        public IResistanceRegimenClassificationService ResistanceRegimen { get; }
        public ISitupsClassificationService Situps { get; set; }
        public ISitAndReachClassificationService SitAndReach { get; set; }
        public ISpirometryClassificationService Spirometry { get; set; }
        public IStretchingRegimenClassificationService Stretching { get; set; }
        public IFitTreadmillScoreClassificationService FitTreadmillScore { get; set; }
        public IVisualAcuityClassificationService VisualAcuity { get; set; }
    }
}