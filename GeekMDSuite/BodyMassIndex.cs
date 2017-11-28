using System;

namespace GeekMDSuite
{
    public class BodyMassIndex : IInterpretable
    {
        public BodyMassIndex(IPatient patient)
        {
            var weightKilograms = patient.BodyWeight.Kilograms;
            var heightMeters = patient.Height.Meters;
            Classification = ClassifyBodyMassIndex(patient);
            Value = CalculateBodyMassIndex(weightKilograms, heightMeters);
        }

        public Interpretation Interpretation => throw new NotImplementedException();
        
        public BodyMassIndexCategory Classification { get; }
        public double Value { get; }

        public static double CalculateBodyMassIndex(double weightKilograms, double heightMeters) =>
            weightKilograms / Math.Pow(heightMeters, 2);

        public static BodyMassIndexCategory ClassifyBodyMassIndex(IPatient patient)
        {
            var bmi = CalculateBodyMassIndex(patient.BodyWeight.Kilograms, patient.Height.Meters);
            var overWeightLowerLimit = patient.Race == Race.Asian ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;
            var obeseClass1LowerLimit = patient.Race == Race.Asian ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
            
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
        private Interpretation _interpretation;

    }
}
