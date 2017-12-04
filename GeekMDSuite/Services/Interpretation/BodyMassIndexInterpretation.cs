using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class BodyMassIndexInterpretation : IInterpretable<BodyMassIndexCategory>
    {
        public BodyMassIndexInterpretation( IBodyComposition bodyComposition, Race race)
        {
            Classification = ClassifyBodyMassIndex(bodyComposition, race);
            Value = CalculateBodyMassIndex(bodyComposition.Weight.Kilograms, bodyComposition.Height.Meters);
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public BodyMassIndexCategory Classification { get; }
        public double Value { get; }

        public static double CalculateBodyMassIndex(double weightKilograms, double heightMeters) =>
            weightKilograms / Math.Pow(heightMeters, 2);
        
        public static BodyMassIndexCategory ClassifyBodyMassIndex(IBodyComposition bodyComposition, Race race)
        {
            var bmi = CalculateBodyMassIndex(bodyComposition.Weight.Kilograms, bodyComposition.Height.Meters);
            var overWeightLowerLimit = race == Race.Asian ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;
            var obeseClass1LowerLimit = race == Race.Asian ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
            
            if (bmi < UnderWeightLowerLimit) return BodyMassIndexCategory.SeverelyUnderweight;
            if (bmi < NormalWeightLowerLimit) return BodyMassIndexCategory.Underweight;
            if (bmi < overWeightLowerLimit) return BodyMassIndexCategory.NormalWeight;
            if (bmi < obeseClass1LowerLimit) return BodyMassIndexCategory.OverWeight;
            if (bmi < ObeseClass2LowerLimit) return BodyMassIndexCategory.ObesityClass1;
            
            return bmi < ObeseClass3LowerLimit ? BodyMassIndexCategory.ObesityClass2 : BodyMassIndexCategory.ObesityClass3;
        }
        
        public static double UnderWeightLowerLimit = 17.5;
        public static double NormalWeightLowerLimit = 18.5;
        public static double OverWeightLowerLimitAsian = 23;
        public static double OverWeightLowerLimitNonAsian = 25;
        public static double ObeseClass1LowerLimitAsian = 27;
        public static double ObeseClass1LowerLimitNonAsian = 30;
        public static double ObeseClass2LowerLimit = 35;
        public static double ObeseClass3LowerLimit = 40;
    }
}
