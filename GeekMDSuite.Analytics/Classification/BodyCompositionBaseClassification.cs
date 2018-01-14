using System;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public abstract class BodyCompositionBaseClassification
    {
        private readonly BodyComposition _bodyComposition;
        private readonly Patient _patient;

        protected BodyCompositionBaseClassification(BodyComposition bodyComposition, Patient patient)
        {
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        public BodyCompositionBaseClassification()
        {
        }

        public HipToWaistRatio HipToWaistRatio =>
            new HipToWaistClassification(new BodyCompositionClassificationParameters(_bodyComposition, _patient))
                .Classification;

        public WaistToHeightRatio WaistToHeightRatio =>
            new WaistToHeightRatioClassification(
                new BodyCompositionClassificationParameters(_bodyComposition, _patient)).Classification;

        public BodyMassIndex BodyMassIndex =>
            new BodyMassIndexClassification(new BodyCompositionClassificationParameters(_bodyComposition, _patient))
                .Classification;

        protected virtual BodyCompositionClassificationResult Classify()
        {
            if (ThinAndLean())
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.ThinAndLean);
            if (SkinnyFat())
                return BodyCompositionClassificationResult.Build(BodyCompositionResult.SkinnyFat);
            return OverWeightButLean()
                ? BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightSuspectMuscular)
                : BodyCompositionClassificationResult.Build(BodyCompositionResult.OverweightOverFat);
        }

        protected bool OverWeightButLean()
        {
            return BmiIsOverweightOrHigher() && BodyProportionsAreLean();
        }

        protected bool BmiIsOverweightOrHigher()
        {
            return !BmiIsNormalOrLower();
        }

        protected virtual bool ThinAndLean()
        {
            return BmiIsNormalOrLower() &&
                   HipToWaistRatioIsNormal() &&
                   WaistToHeightRatioIsHealthyOrSlimmer();
        }

        private bool BodyProportionsAreLean()
        {
            return WaistToHeightRatioIsHealthyOrSlimmer() && HipToWaistRatioIsNormal();
        }

        private bool WaistToHeightRatioIsHealthyOrSlimmer()
        {
            return WaistToHeightRatio == WaistToHeightRatio.Healthy ||
                   WaistToHeightRatio == WaistToHeightRatio.Slim ||
                   WaistToHeightRatio == WaistToHeightRatio.ExtremelySlim;
        }

        private bool HipToWaistRatioIsNormal()
        {
            return HipToWaistRatio == HipToWaistRatio.Normal;
        }

        protected bool SkinnyFat()
        {
            return (HipToWaistRatioSuggestsOverweightOrObese() || WaistToHeightRatioSuggestsOverweightOrObese())
                   && BmiIsNormalOrLower();
        }

        private bool BmiIsNormalOrLower()
        {
            return BodyMassIndex == BodyMassIndex.NormalWeight
                   || BodyMassIndex == BodyMassIndex.Underweight
                   || BodyMassIndex == BodyMassIndex.SeverelyUnderweight;
        }

        private bool WaistToHeightRatioSuggestsOverweightOrObese()
        {
            return WaistToHeightRatio == WaistToHeightRatio.Overweight
                   || WaistToHeightRatio == WaistToHeightRatio.VeryOverweight
                   || WaistToHeightRatio == WaistToHeightRatio.MorbidlyObese;
        }

        private bool HipToWaistRatioSuggestsOverweightOrObese()
        {
            return HipToWaistRatio == HipToWaistRatio.Obese
                   || HipToWaistRatio == HipToWaistRatio.Overweight;
        }
    }
}