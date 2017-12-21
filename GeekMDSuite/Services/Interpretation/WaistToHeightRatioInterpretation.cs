using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class WaistToHeightRatioInterpretation : IInterpretable<WaistToHeightRatio>
    {

        public WaistToHeightRatioInterpretation(IBodyComposition bodyComposition, IPatient patient)
        {
            _waistToHeighRatio = Calculate(bodyComposition);
            _patient = patient;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public WaistToHeightRatio Classification => Classify();

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
        private readonly IPatient _patient;
        
        private static double Calculate(IBodyComposition bodyComposition) => 
            bodyComposition.Waist.Centimeters / bodyComposition.Height.Centimeters;
        
        private WaistToHeightRatio Classify()
        {
            var slim = Gender.IsGenotypeXy(_patient.Gender) ? LowerLimits.Male.Slim : LowerLimits.Female.Slim;
            var healthy = Gender.IsGenotypeXy(_patient.Gender) ? LowerLimits.Male.Healthy : LowerLimits.Female.Healthy;
            var overweight = Gender.IsGenotypeXy(_patient.Gender) ? LowerLimits.Male.Overweight : LowerLimits.Female.Overweight;
            var veryOverweight = Gender.IsGenotypeXy(_patient.Gender)
                ? LowerLimits.Male.VeryOverweight
                : LowerLimits.Female.VeryOverweight;
            var morbidlyObese =
                Gender.IsGenotypeXy(_patient.Gender) ? LowerLimits.Male.MorbidlyObese : LowerLimits.Female.MoribdlyObese;

            if (_waistToHeighRatio < slim)
                return WaistToHeightRatio.ExtremelySlim;
            if (_waistToHeighRatio < healthy)
                return WaistToHeightRatio.Slim;
            if (_waistToHeighRatio < overweight)
                return WaistToHeightRatio.Healthy;
            if (_waistToHeighRatio < veryOverweight)
                return WaistToHeightRatio.Overweight;
            return _waistToHeighRatio < morbidlyObese
                ? WaistToHeightRatio.VeryOverweight
                : WaistToHeightRatio.MorbidlyObese;
        }
    }
}
