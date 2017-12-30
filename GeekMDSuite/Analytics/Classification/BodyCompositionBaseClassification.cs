using System;

namespace GeekMDSuite.Analytics.Classification
{
    public abstract class BodyCompositionBaseClassification
    {
        protected BodyCompositionBaseClassification(IBodyComposition bodyComposition, IPatient patient)
        {
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public HipToWaistRatio HipToWaistRatio => new HipToWaistClassification(_bodyComposition, _patient).Classification;
        public WaistToHeightRatio WaistToHeightRatio => new WaistToHeightRatioClassification(_bodyComposition, _patient).Classification;
        public BodyMassIndex BodyMassIndex => new BodyMassIndexClassification(_bodyComposition, _patient).Classification;

        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;
        
        protected virtual BodyCompositionResult Classify()
        {
            if (ThinAndLean()) 
                return BodyCompositionResult.ThinAndLean;
            if (SkinnyFat()) 
                return BodyCompositionResult.SkinnyFat;
            return OverWeightButLean() ? BodyCompositionResult.OverweightSuspectMuscular 
                : BodyCompositionResult.OverweightOverFat;
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
}