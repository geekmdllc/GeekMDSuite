using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation.BodyComposition
{
    public static class BodyMassIndex
    {
        public static BodyMassIndexCategory Classification(IPatient patient)
        {
           return ClassifyBodyMassIndex(patient);
        }

        private static BodyMassIndexCategory ClassifyBodyMassIndex(IPatient patient)
        {
            var bmi = Calculations.BodyComposition.BodyMassIndexCalculation(patient);
            var overWeightLowerLimit = patient.Race == Race.Asian ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;
            var obeseClass1LowerLimit = patient.Race == Race.Asian ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
            
            if (bmi < UnderWeightLowerLimit)
                return BodyMassIndexCategory.SeverelyUnderweight;
            if (bmi < NormalWeightLowerLimit)
                return BodyMassIndexCategory.Underweight;
            if (bmi < overWeightLowerLimit)
                return BodyMassIndexCategory.NormalWeight;
            if (bmi < obeseClass1LowerLimit)
                return BodyMassIndexCategory.OverWeight;
            if (bmi < ObeseClass2LowerLimit)
                return BodyMassIndexCategory.ObesityClass1;
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