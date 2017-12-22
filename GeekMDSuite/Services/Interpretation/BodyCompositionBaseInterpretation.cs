using System;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionBaseInterpretation
    {
        protected BodyCompositionBaseInterpretation(IBodyComposition bodyComposition, IPatient patient)
        {
            _bodyComposition = bodyComposition;
            _patient = patient;
        }

        public HipToWaistRatio HipToWaistRatio => new HipToWaistInterpretation(_bodyComposition, _patient).Classification;
        public WaistToHeightRatio WaistToHeightRatio => new WaistToHeightRatioInterpretation(_bodyComposition, _patient).Classification;
        public BodyMassIndex BodyMassIndex => new BodyMassIndexInterpretation(_bodyComposition, _patient).Classification;

        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;
        
        protected virtual BodyCompositionClassification Classify()
        {
            if (ThinAndLean()) 
                return BodyCompositionClassification.ThinAndLean;
            if (SkinnyFat()) 
                return BodyCompositionClassification.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionClassification.OverweightSuspectMuscular 
                : BodyCompositionClassification.OverweightOverFat;
        }

        protected bool OverWeightButLean()
        {
            return BmiIsOverweightOrHigher() && BodyProportionsAreLean();
        }

        protected bool BmiIsOverweightOrHigher() => !BmiIsNormalOrLower();

        protected virtual bool ThinAndLean() => BmiIsNormalOrLower() && 
                                                HipToWaistRatioIsNormal() &&
                                                WaistToHeightRatioIsHealthyOrSlimmer();

        protected bool BodyProportionsAreLean() => WaistToHeightRatioIsHealthyOrSlimmer() && HipToWaistRatioIsNormal();

        protected bool WaistToHeightRatioIsHealthyOrSlimmer() => (WaistToHeightRatio == WaistToHeightRatio.Healthy || 
                                                                  WaistToHeightRatio == WaistToHeightRatio.Slim ||
                                                                  WaistToHeightRatio == WaistToHeightRatio.ExtremelySlim);

        protected bool HipToWaistRatioIsNormal() => (HipToWaistRatio == HipToWaistRatio.Normal);

        protected bool SkinnyFat() => (HipToWaistRatioSuggestsOverweightOrObese() || WaistToHeightRatioSuggestsOverweightOrObese())
                                      && BmiIsNormalOrLower();

        protected bool BmiIsNormalOrLower() => (BodyMassIndex == BodyMassIndex.NormalWeight
                                                || BodyMassIndex == BodyMassIndex.Underweight
                                                || BodyMassIndex == BodyMassIndex.SeverelyUnderweight);

        protected bool WaistToHeightRatioSuggestsOverweightOrObese() => WaistToHeightRatio == WaistToHeightRatio.Overweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.VeryOverweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.MorbidlyObese;

        protected bool HipToWaistRatioSuggestsOverweightOrObese() => HipToWaistRatio == HipToWaistRatio.Obese
                                                                     || HipToWaistRatio == HipToWaistRatio.Overweight;
    }
    
    public class BodyCompositionInterpretationResult
    {
        public BodyCompositionInterpretationResult(IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient;
            _bodyComposition = bodyComposition;
        }
        
        public HipToWaistRatio HipToWaistRatio => new HipToWaistInterpretation(_bodyComposition, _patient).Classification;
        public WaistToHeightRatio WaistToHeightRatio => new WaistToHeightRatioInterpretation(_bodyComposition, _patient).Classification;
        public BodyMassIndex BodyMassIndex => new BodyMassIndexInterpretation(_bodyComposition, _patient).Classification;

        public BodyCompositionClassification Classification => Classify();

        
        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;
        
        protected virtual BodyCompositionClassification Classify()
        {
            if (ThinAndLean()) 
                return BodyCompositionClassification.ThinAndLean;
            if (SkinnyFat()) 
                return BodyCompositionClassification.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionClassification.OverweightSuspectMuscular 
                : BodyCompositionClassification.OverweightOverFat;
        }

        protected bool OverWeightButLean()
        {
            return BmiIsOverweightOrHigher() && BodyProportionsAreLean();
        }

        protected bool BmiIsOverweightOrHigher() => !BmiIsNormalOrLower();

        protected virtual bool ThinAndLean() => BmiIsNormalOrLower() && 
                                                HipToWaistRatioIsNormal() &&
                                                WaistToHeightRatioIsHealthyOrSlimmer();

        protected bool BodyProportionsAreLean() => WaistToHeightRatioIsHealthyOrSlimmer() && HipToWaistRatioIsNormal();

        protected bool WaistToHeightRatioIsHealthyOrSlimmer() => (WaistToHeightRatio == WaistToHeightRatio.Healthy || 
                                                                  WaistToHeightRatio == WaistToHeightRatio.Slim ||
                                                                  WaistToHeightRatio == WaistToHeightRatio.ExtremelySlim);

        protected bool HipToWaistRatioIsNormal() => (HipToWaistRatio == HipToWaistRatio.Normal);

        protected bool SkinnyFat() => (HipToWaistRatioSuggestsOverweightOrObese() || WaistToHeightRatioSuggestsOverweightOrObese())
                                      && BmiIsNormalOrLower();

        protected bool BmiIsNormalOrLower() => (BodyMassIndex == BodyMassIndex.NormalWeight
                                                || BodyMassIndex == BodyMassIndex.Underweight
                                                || BodyMassIndex == BodyMassIndex.SeverelyUnderweight);

        protected bool WaistToHeightRatioSuggestsOverweightOrObese() => WaistToHeightRatio == WaistToHeightRatio.Overweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.VeryOverweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.MorbidlyObese;

        protected bool HipToWaistRatioSuggestsOverweightOrObese() => HipToWaistRatio == HipToWaistRatio.Obese
                                                                     || HipToWaistRatio == HipToWaistRatio.Overweight;
    }

    public class BodyCompositionExpandedInterpretationResult : BodyCompositionInterpretationResult
    {

        public BodyCompositionExpandedInterpretationResult(IBodyCompositionExpanded bodyComposition, IPatient patient) 
            : base(bodyComposition, patient)
        {
            _patient = patient;
            _bodyCompositionExpanded = bodyComposition;
        }

        public PercentBodyFat PercentBodyFat =>
            new PercentBodyFatInterpretation(_bodyCompositionExpanded, _patient).Classification;
        
        public VisceralFat VisceralFat =>
            new VisceralFatInterpretation(_bodyCompositionExpanded).Classification;

        private readonly IBodyCompositionExpanded _bodyCompositionExpanded;
        private readonly IPatient _patient;

        protected override BodyCompositionClassification Classify()
        {
            if (ThinAndLean())
                return BodyCompositionClassification.ThinAndLean;
            if (MuscularAndLean())
                return BodyCompositionClassification.MuscularAndLean;
            if (SkinnyFat()) 
                return BodyCompositionClassification.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionClassification.OverweightSuspectMuscular 
                : BodyCompositionClassification.OverweightOverFat;
        }

        protected bool MuscularAndLean() => BmiIsOverweightOrHigher() && BodyFatIsLean() && VisceralFatIsLean();

        protected override bool ThinAndLean() => BodyFatIsLean() && VisceralFatIsLean() && base.ThinAndLean();

        protected bool BodyFatIsLean() => PercentBodyFat == PercentBodyFat.Fitness ||
                                          PercentBodyFat == PercentBodyFat.Athletic ||
                                          PercentBodyFat == PercentBodyFat.UnderFat;

        protected bool VisceralFatIsLean() => VisceralFat == VisceralFat.Excellent || 
                                              VisceralFat == VisceralFat.Acceptable;
    }

    
}