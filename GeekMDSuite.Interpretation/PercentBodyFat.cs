using GeekMDSuite.Common;
using GenderEval = GeekMDSuite.Common.Gender;

namespace GeekMDSuite.Interpretation
{
    public static class PercentBodyFat
    {       
        public static BodyFatCategories Interpret (Genders gender, double result) => CategorizeBodyFat(gender, result);

        private static BodyFatCategories CategorizeBodyFat(Genders gender, double result)
        {
            var athletic = GenderEval.IsXy(gender) ? AthleticBodyFatLowerLimitMale : AthleticBodyFatLowerLimitFemale;
            var fitness = GenderEval.IsXy(gender) ? FitnessBodyFatLowerLimitMale : FitnessBodyFatLowerLimitFemale;
            var acceptable = GenderEval.IsXy(gender) ? AcceptableBodyFatLowerLimitMale : AcceptableBodyFatLowerLimitFemale;
            var overfat = GenderEval.IsXy(gender) ? OverFatLowerLimitMale : OverFatLowerLimitFemale;
            
            if (result < athletic)
                return BodyFatCategories.UnderFat;
            if (result < fitness)
                return BodyFatCategories.Athletic;
            if (result < acceptable)
                return BodyFatCategories.Fitness;
            return result < overfat ? BodyFatCategories.Acceptable : BodyFatCategories.OverFat;
        }
        
        public static double AthleticBodyFatLowerLimitMale = 6;
        public static double AthleticBodyFatLowerLimitFemale = 14;
        public static double FitnessBodyFatLowerLimitMale = 14;
        public static double FitnessBodyFatLowerLimitFemale = 21;
        public static double AcceptableBodyFatLowerLimitMale = 18;
        public static double AcceptableBodyFatLowerLimitFemale = 25;
        public static double OverFatLowerLimitMale = 25;
        public static double OverFatLowerLimitFemale = 32;
    }
}