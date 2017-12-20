using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class WaistToHeightRatioInterpretation : IInterpretable<WaistToHeightRatioClassification>
    {

        public WaistToHeightRatioInterpretation(IBodyComposition bodyComposition, GenderIdentity gender)
        {
            _waistToHeighRatio = Calculate(bodyComposition);
            _gender = gender;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public WaistToHeightRatioClassification Classification => Classify();

        public static class LowerLimits
        {
            public static class Male
            {
                public const double Slim = 0.34;
                public const double Healthy = 0.43;
                public const double Overweight = 0.53;
                public const double VeryOverweight = 0.58;
                public const double MorbidlyObese = 0.63;
            }
            public static class Female
            {                
                public const double Slim = 0.34;
                public const double Healthy = 0.42;
                public const double Overweight = 0.49;
                public const double VeryOverweight = 0.54;
                public const double MoribdlyObese = 0.58;
            }
        }
        
        private readonly double _waistToHeighRatio;
        private readonly GenderIdentity _gender;
        
        private static double Calculate(IBodyComposition bodyComposition) => 
            bodyComposition.Waist.Centimeters / bodyComposition.Height.Centimeters;
        
        private WaistToHeightRatioClassification Classify()
        {
            var slim = Gender.IsGenotypeXy(_gender) ? LowerLimits.Male.Slim : LowerLimits.Female.Slim;
            var healthy = Gender.IsGenotypeXy(_gender) ? LowerLimits.Male.Healthy : LowerLimits.Female.Healthy;
            var overweight = Gender.IsGenotypeXy(_gender) ? LowerLimits.Male.Overweight : LowerLimits.Female.Overweight;
            var veryOverweight = Gender.IsGenotypeXy(_gender)
                ? LowerLimits.Male.VeryOverweight
                : LowerLimits.Female.VeryOverweight;
            var morbidlyObese =
                Gender.IsGenotypeXy(_gender) ? LowerLimits.Male.MorbidlyObese : LowerLimits.Female.MoribdlyObese;

            if (_waistToHeighRatio < slim)
                return WaistToHeightRatioClassification.ExtremelySlim;
            if (_waistToHeighRatio < healthy)
                return WaistToHeightRatioClassification.Slim;
            if (_waistToHeighRatio < overweight)
                return WaistToHeightRatioClassification.Healthy;
            if (_waistToHeighRatio < veryOverweight)
                return WaistToHeightRatioClassification.Overweight;
            return _waistToHeighRatio < morbidlyObese
                ? WaistToHeightRatioClassification.VeryOverweight
                : WaistToHeightRatioClassification.MorbidlyObese;
        }
    }
}
