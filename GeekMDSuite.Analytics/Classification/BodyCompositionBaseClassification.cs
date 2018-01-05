using System;
using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public abstract class BodyCompositionBaseClassification
    {
        protected BodyCompositionBaseClassification(BodyComposition bodyComposition, Patient patient)
        {
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public BodyCompositionBaseClassification()
        {
            
        }

        public HipToWaistRatio HipToWaistRatio => new HipToWaistClassification(_bodyComposition, _patient).Classification;
        public WaistToHeightRatio WaistToHeightRatio => new WaistToHeightRatioClassification(_bodyComposition, _patient).Classification;
        public BodyMassIndex BodyMassIndex => new BodyMassIndexClassification(_bodyComposition, _patient).Classification;

        private readonly BodyComposition _bodyComposition;
        private readonly Patient _patient;
        
        protected virtual BodyCompositionClassificationResult Classify()
        {
            if (ThinAndLean()) 
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.ThinAndLean);
            if (SkinnyFat()) 
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.SkinnyFat);
            return OverWeightButLean() ? BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightSuspectMuscular) 
                : BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightOverFat);
        }

        protected bool OverWeightButLean()
        {
            return BmiIsOverweightOrHigher() && BodyProportionsAreLean();
        }

        protected bool BmiIsOverweightOrHigher() => !BmiIsNormalOrLower();

        protected virtual bool ThinAndLean() => BmiIsNormalOrLower() && 
                                                HipToWaistRatioIsNormal() &&
                                                WaistToHeightRatioIsHealthyOrSlimmer();

        private bool BodyProportionsAreLean() => WaistToHeightRatioIsHealthyOrSlimmer() && HipToWaistRatioIsNormal();

        private bool WaistToHeightRatioIsHealthyOrSlimmer() => (WaistToHeightRatio == WaistToHeightRatio.Healthy || 
                                                                  WaistToHeightRatio == WaistToHeightRatio.Slim ||
                                                                  WaistToHeightRatio == WaistToHeightRatio.ExtremelySlim);

        private bool HipToWaistRatioIsNormal() => (HipToWaistRatio == HipToWaistRatio.Normal);

        protected bool SkinnyFat() => (HipToWaistRatioSuggestsOverweightOrObese() || WaistToHeightRatioSuggestsOverweightOrObese())
                                      && BmiIsNormalOrLower();

        private bool BmiIsNormalOrLower() => (BodyMassIndex == BodyMassIndex.NormalWeight
                                                || BodyMassIndex == BodyMassIndex.Underweight
                                                || BodyMassIndex == BodyMassIndex.SeverelyUnderweight);

        private bool WaistToHeightRatioSuggestsOverweightOrObese() => WaistToHeightRatio == WaistToHeightRatio.Overweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.VeryOverweight
                                                                        || WaistToHeightRatio == WaistToHeightRatio.MorbidlyObese;

        private bool HipToWaistRatioSuggestsOverweightOrObese() => HipToWaistRatio == HipToWaistRatio.Obese
                                                                     || HipToWaistRatio == HipToWaistRatio.Overweight;
    }
}