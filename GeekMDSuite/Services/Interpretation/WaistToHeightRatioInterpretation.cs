using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class WaistToHeightRatioInterpretation : IInterpretable
    {
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public static WaistToHeightRatioClassification Interpret (GenderIdentity gender, double result) => Classify(gender, result);
        
        public static double WaistToHeightRatioCalculation(IBodyComposition bodyComposition) => 
            bodyComposition.Waist.Centimeters / bodyComposition.Height.Centimeters;
        
        private  static WaistToHeightRatioClassification Classify(GenderIdentity gender, double result)
        {
            
            var slim = Gender.IsGenotypeXy(gender) ? LowerLimits.Male.Slim : LowerLimits.Female.Slim;
            var healthy = Gender.IsGenotypeXy(gender) ? LowerLimits.Male.Healthy : LowerLimits.Female.Healthy;
            var overweight = Gender.IsGenotypeXy(gender) ? LowerLimits.Male.Overweight : LowerLimits.Female.Overweight;
            var veryOverweight = Gender.IsGenotypeXy(gender) ? LowerLimits.Male.VeryOverweight : LowerLimits.Female.VeryOverweight;
            var morbidlyObese = Gender.IsGenotypeXy(gender) ? LowerLimits.Male.MorbidlyObese : LowerLimits.Female.MoribdlyObese;
            
            if (result < slim)
                return WaistToHeightRatioClassification.ExtremelySlim;
            if (result < healthy)
                return WaistToHeightRatioClassification.Slim;
            if (result < overweight)
                return WaistToHeightRatioClassification.Healthy;
            if (result < veryOverweight)
                return WaistToHeightRatioClassification.Overweight;
            return result < morbidlyObese
                ? WaistToHeightRatioClassification.VeryOverweight
                : WaistToHeightRatioClassification.MorbidlyObese;
        }

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
    }
}