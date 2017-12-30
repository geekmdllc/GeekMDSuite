using System;
using GeekMDSuite.Tools.BodyComposition;

namespace GeekMDSuite.Analytics.Classification
{
    public class BodyMassIndexClassification : IClassifiable<BodyMassIndex>
    {
        public BodyMassIndexClassification( IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
        }

        public BodyMassIndex Classification => Classify();
        
        public static class LowerLimits
        {
            public static class Overweight
            {
                public const double Asian = 23;
                public const double NonAsian = 25;
            }

            public static class ObeseClass1
            {
                public const double Asian = 27;
                public const double NonAsian = 30;
            }
            public const double UnderWeight = 17.5;
            public const double NormalWeight = 18.5;
            public const double ObeseClass2 = 35;
            public const double ObeseClass3 = 40;
        }

        public override string ToString() => Classification.ToString();

        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;

        private BodyMassIndex Classify()
        {
            var bmi = CalculateBodyMassIndex.Calculate(_bodyComposition.Weight.Kilograms, _bodyComposition.Height.Meters);
            var overWeightLowerLimit = _patient.Race == Race.Asian 
                ? LowerLimits.Overweight.Asian : LowerLimits.Overweight.NonAsian;
            var obeseClass1LowerLimit = _patient.Race == Race.Asian 
                ? LowerLimits.ObeseClass1.Asian : LowerLimits.ObeseClass1.NonAsian;
            
            if (bmi < LowerLimits.UnderWeight) return BodyMassIndex.SeverelyUnderweight;
            if (bmi < LowerLimits.NormalWeight) return BodyMassIndex.Underweight;
            if (bmi < overWeightLowerLimit) return BodyMassIndex.NormalWeight;
            if (bmi < obeseClass1LowerLimit) return BodyMassIndex.OverWeight;
            if (bmi < LowerLimits.ObeseClass2) return BodyMassIndex.ObesityClass1;
            return bmi < LowerLimits.ObeseClass3 ? BodyMassIndex.ObesityClass2 
                : BodyMassIndex.ObesityClass3;
        }
    }
}
