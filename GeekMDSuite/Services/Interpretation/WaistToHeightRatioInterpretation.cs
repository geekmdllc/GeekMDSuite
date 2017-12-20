using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class HipToWaistInterpretation : IInterpretable<WaistToHeightRatioClassification>
    {
        public HipToWaistInterpretation(IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient;
            _bodyComposition = bodyComposition;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public WaistToHeightRatioClassification Classification => throw new NotImplementedException();
        public double Ratio => _bodyComposition.Hips.Inches / _bodyComposition.Waist.Inches;

        private WaistToHeightRatioClassification Classify()
        {
            var limits = SetLimits();

            throw new NotImplementedException();
        }

        private HipToWaistLowerLimits SetLimits()
        {
            if (Gender.IsGenotypeXy(_patient.Gender))
                return new HipToWaistLowerLimits(
                    LowerLimits.Male.Normal,
                    LowerLimits.Male.Overweight,
                    LowerLimits.Male.Obese);
            
            return new HipToWaistLowerLimits(
                LowerLimits.Female.Normal,
                LowerLimits.Female.Overweight,
                LowerLimits.Female.Obese
            );
        }
        private class HipToWaistLowerLimits
        {
            public HipToWaistLowerLimits(double normal, double overweight, double obese)
            {
                Normal = normal;
                Overweight = overweight;
                Obese = obese;
            }

            public double Normal { get;}
            public double Overweight { get;}
            public double Obese { get;}
        }

        public static class LowerLimits
        {
            public static class Female
            {
                public const double Normal = 0;
                public const double Overweight = 0.8;
                public const double Obese = 0.85;
            }

            public static class Male
            {
                public const double Normal = 0;
                public const double Overweight = 0.9;
                public const double Obese = 1.0;
            }
        }
        
        private IBodyComposition _bodyComposition;
        private IPatient _patient;
    }
    
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
