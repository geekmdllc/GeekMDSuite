using System;
using GeekMDSuite.Analytics.Interpretation;

namespace GeekMDSuite.Analytics.Classification
{
    public class HipToWaistClassification : IClassifiable<HipToWaistRatio>
    {
        public HipToWaistClassification(IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
        }
        
        public HipToWaistRatio Classification => Classify();
        public double Ratio =>  _bodyComposition.Waist.Inches / _bodyComposition.Hips.Inches;

        public override string ToString() => Classification.ToString();

        private HipToWaistRatio Classify()
        {
            var lowerLimits = GetLimits();
            
            if (Ratio < lowerLimits.Normal) 
                throw new ArgumentOutOfRangeException(nameof(Ratio));
            if (Ratio < lowerLimits.Overweight) 
                return HipToWaistRatio.Normal;
            return Ratio < lowerLimits.Obese 
                ? HipToWaistRatio.Overweight : HipToWaistRatio.Obese;
        }

        private HipToWaistLowerLimits GetLimits()
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
}