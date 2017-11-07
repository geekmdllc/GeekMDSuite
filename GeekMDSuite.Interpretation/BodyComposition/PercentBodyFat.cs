using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using GeekMDSuite.Interpretation.BodyComposition;
using GenderEval = GeekMDSuite.Common.Models.Gender;

namespace GeekMDSuite.Interpretation
{
    public static class PercentBodyFat
    {       
        public static BodyFatClassification Interpret (GenderIdentity gender, double result) => Classify(gender, result);

        private static BodyFatClassification Classify(GenderIdentity gender, double result)
        {
            var athletic = GenderEval.IsGenotypeXy(gender) ? AthleticMaleLLN : AthleticFemaleLLN;
            var fitness = GenderEval.IsGenotypeXy(gender) ? FitMaleLLN : FitFemaleLLN;
            var acceptable = GenderEval.IsGenotypeXy(gender) ? AcceptableMaleLLN : AcceptableFemaleLLN;
            var overfat = GenderEval.IsGenotypeXy(gender) ? OverFatMaleLLN : OverFatFemaleLLN;
            
            if (result < athletic)
                return BodyFatClassification.UnderFat;
            if (result < fitness)
                return BodyFatClassification.Athletic;
            if (result < acceptable)
                return BodyFatClassification.Fitness;
            return result < overfat ? BodyFatClassification.Acceptable : BodyFatClassification.OverFat;
        }
        
        public static double AthleticMaleLLN = 6;
        public static double AthleticFemaleLLN = 14;
        public static double FitMaleLLN = 14;
        public static double FitFemaleLLN = 21;
        public static double AcceptableMaleLLN = 18;
        public static double AcceptableFemaleLLN = 25;
        public static double OverFatMaleLLN = 25;
        public static double OverFatFemaleLLN = 32;
    }
}