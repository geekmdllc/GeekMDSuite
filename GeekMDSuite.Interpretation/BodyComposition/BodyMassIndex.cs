using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation.BodyComposition
{
    public static class BodyMassIndex
    {
        public static BodyMassIndexCategory Interpretation (Race race, double result) => ClassifyBodyMassIndex (race, result);

        private static BodyMassIndexCategory ClassifyBodyMassIndex(Race race, double result)
        {
            var overWeightLowerLimit = race == Race.Asian ? OverWeightLowerLimitAsian : OverWeightLowerLimitNonAsian;
            var obeseClass1LowerLimit = race == Race.Asian ? ObeseClass1LowerLimitAsian : ObeseClass1LowerLimitNonAsian;
            
            if (result < UnderWeightLowerLimit)
                return BodyMassIndexCategory.SeverelyUnderweight;
            if (result < NormalWeightLowerLimit)
                return BodyMassIndexCategory.Underweight;
            if (result < overWeightLowerLimit)
                return BodyMassIndexCategory.NormalWeight;
            if (result < obeseClass1LowerLimit)
                return BodyMassIndexCategory.OverWeight;
            if (result < ObeseClass2LowerLimit)
                return BodyMassIndexCategory.ObesityClass1;
            return result < ObeseClass3LowerLimit ? BodyMassIndexCategory.ObesityClass2 : BodyMassIndexCategory.ObesityClass3;
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