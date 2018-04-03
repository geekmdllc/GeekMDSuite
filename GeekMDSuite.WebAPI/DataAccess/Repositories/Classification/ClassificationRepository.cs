using System;
using GeekMDSuite.Analytics.Classification;
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
            IshiharaSixPlateScreens = new IshiharaSixPlateScreenService();
            OccularPressureService = new OccularPressureService();
            PeripheralVisionService = new PeripheralVisionService();
            // Pushups
            QualitativeLabsService = new QualitativeLabService();
            QuantitativeLabsService = new QuantitativeLabService();
            ResistanceRegimens = new ResistanceRegimenClassificationServiceService();
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
        public IOccularPressureService OccularPressureService { get;  }
        public IPeripheralVisionService PeripheralVisionService { get;  }
        // Pushups
        public IQualitativeLabsService QualitativeLabsService { get; set; }
        public IQuantitativeLabsService QuantitativeLabsService { get; set; }
        public IResistanceRegimenClassificationService ResistanceRegimens { get; }
    }
}