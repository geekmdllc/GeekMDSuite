using System;
using GeekMDSuite.Tools.BodyComposition;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyMassIndexInterpretation : IInterpretable<BodyMassIndexCategory>
    {
        public BodyMassIndexInterpretation( IBodyComposition bodyComposition, IPatient patient)
        {
            _patient = patient;
            _bodyComposition = bodyComposition;
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public BodyMassIndexCategory Classification => Classify();
        
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

        private readonly IBodyComposition _bodyComposition;
        private readonly IPatient _patient;

        private BodyMassIndexCategory Classify()
        {
            var bmi = CalculateBodyMassIndex.Calculate(_bodyComposition.Weight.Kilograms, _bodyComposition.Height.Meters);
            var overWeightLowerLimit = _patient.Race == Race.Asian 
                ? LowerLimits.Overweight.Asian : LowerLimits.Overweight.NonAsian;
            var obeseClass1LowerLimit = _patient.Race == Race.Asian 
                ? LowerLimits.ObeseClass1.Asian : LowerLimits.ObeseClass1.NonAsian;
            
            if (bmi < LowerLimits.UnderWeight) return BodyMassIndexCategory.SeverelyUnderweight;
            if (bmi < LowerLimits.NormalWeight) return BodyMassIndexCategory.Underweight;
            if (bmi < overWeightLowerLimit) return BodyMassIndexCategory.NormalWeight;
            if (bmi < obeseClass1LowerLimit) return BodyMassIndexCategory.OverWeight;
            if (bmi < LowerLimits.ObeseClass2) return BodyMassIndexCategory.ObesityClass1;
            return bmi < LowerLimits.ObeseClass3 ? BodyMassIndexCategory.ObesityClass2 
                : BodyMassIndexCategory.ObesityClass3;
        }
    }
}
