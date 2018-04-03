using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification.CompositeScores;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification
{
    public interface IClassificationRepository
    {
        IAscvdClassificationService AscvdScores { get; }
        IAudiogramClassificationService Audiograms { get; }
        IBloodPressureClassificationService BloodPressures { get; }
        IBodyCompositionClassificationService BodyCompositions { get; }
        IBodyCompositionExpandedClassificationService BodyCompositionsExpanded { get; }
        ICarotidUltrasoundClassificationService CarotidUltrasounds { get; }
        ICardiovascularRegimenClassificationService CardiovascularRegimens { get; }
        ICentralBloodPressureClassificationService CentralBloodPressures { get; }
        IFunctionalMovementClassificationService FunctionalMovements { get; }
        IGripStrengthClassificationService GripStrengths { get; }
        IIshiharaSixPlateScreenService IshiharaSixPlateScreens { get; }
        IOccularPressureService OccularPressureService { get; }
        IPeripheralVisionService PeripheralVisionService { get; }
        // IPushups
        IQualitativeLabsService QualitativeLabsService { get; }
        IQuantitativeLabsService QuantitativeLabsService { get; }
        IResistanceRegimenClassificationService ResistanceRegimens { get; }
    }
}