using System;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionBaseInterpretation
    {
        protected BodyCompositionBaseInterpretation(IBodyComposition bodyComposition)
        {
            _bodyComposition = bodyComposition;
        }
        
        private IBodyComposition _bodyComposition;

        protected virtual BodyCompositionClassification Classify() => throw new NotImplementedException();
    }
    
    public class BodyCompositionInterpretationResult
    {
        public BodyCompositionInterpretationResult(IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient;
            _bodyComposition = bodyComposition;
        }

        public BodyCompositionClassification Classification => Classify();

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
            return !BmiIsNormalOrLower() && BodyProportionsAreLean();
        }

        protected bool ThinAndLean()
        {
            return BmiIsNormalOrLower() && 
                   HipToWaistRatioIsNormal() &&
                   WaistToHeightRatioIsHealthyOrSlimmer();
        }

        protected bool BodyProportionsAreLean()
        {
            return WaistToHeightRatioIsHealthyOrSlimmer() && HipToWaistRatioIsNormal();
        }

        protected bool WaistToHeightRatioIsHealthyOrSlimmer()
        {
            return (WaistToHeightRatio == WaistToHeightRatio.Healthy || 
                    WaistToHeightRatio == WaistToHeightRatio.Slim ||
                    WaistToHeightRatio == WaistToHeightRatio.ExtremelySlim);
        }

        protected bool HipToWaistRatioIsNormal()
        {
            return (HipToWaistRatio == HipToWaistRatio.Normal);
        }

        protected bool SkinnyFat()
        {
            return (HipToWaistRatioSuggestsOverweightOrObese() || WaistToHeightRatioSuggestsOverweightOrObese())
                   && BmiIsNormalOrLower();
        }

        protected bool BmiIsNormalOrLower()
        {
            return (BodyMassIndex == BodyMassIndex.NormalWeight
                    || BodyMassIndex == BodyMassIndex.Underweight
                    || BodyMassIndex == BodyMassIndex.SeverelyUnderweight);
        }

        protected bool WaistToHeightRatioSuggestsOverweightOrObese()
        {
            return WaistToHeightRatio == WaistToHeightRatio.Overweight
                   || WaistToHeightRatio == WaistToHeightRatio.VeryOverweight
                   || WaistToHeightRatio == WaistToHeightRatio.MorbidlyObese;
        }

        protected bool HipToWaistRatioSuggestsOverweightOrObese()
        {
            return HipToWaistRatio == HipToWaistRatio.Obese
                   || HipToWaistRatio == HipToWaistRatio.Overweight;
        }

    }

    
}