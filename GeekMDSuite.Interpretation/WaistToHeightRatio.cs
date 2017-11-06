using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation
{
    public static class WaistToHeightRatio
    {
        
        public static WaistToHeightRatioClassification Interpret (GenderIdentity gender, double result) => Classify(gender, result);
        
        private  static WaistToHeightRatioClassification Classify(GenderIdentity gender, double result)
        {
            
            var slim = Gender.IsGenotypeXy(gender) ? SlimMaleLLN : SlimFemaleLLN;
            var healthy = Gender.IsGenotypeXy(gender) ? HealthyMaleLLN : HealthyFemaleLLN;
            var overweight = Gender.IsGenotypeXy(gender) ? OverweightMaleLLN : OverweightFemaleLLN;
            var veryOverweight = Gender.IsGenotypeXy(gender) ? VeryOverweightMaleLLN : VeryOverweightFemaleLLN;
            var morbidlyObese = Gender.IsGenotypeXy(gender) ? MorbidlyObeseMaleLLN : MoribdlyObeseFemaleLLN;
            
            if (result < slim)
                return WaistToHeightRatioClassification.ExtremelySlim;
            if (result < healthy)
                return WaistToHeightRatioClassification.Slim;
            if (result < overweight)
                return WaistToHeightRatioClassification.Healthy;
            if (result < veryOverweight)
                return WaistToHeightRatioClassification.Overweight;
            return result < morbidlyObese
                ? WaistToHeightRatioClassification.VeryOverweight
                : WaistToHeightRatioClassification.MorbidlyObese;
        }
        
        public static double SlimMaleLLN = 0.34;
        public static double SlimFemaleLLN = 0.34;
        public static double HealthyMaleLLN = 0.43;
        public static double HealthyFemaleLLN = 0.42;
        public static double OverweightMaleLLN = 0.53;
        public static double OverweightFemaleLLN = 0.49;
        public static double VeryOverweightMaleLLN = 0.58;
        public static double VeryOverweightFemaleLLN = 0.54;
        public static double MorbidlyObeseMaleLLN = 0.63;
        public static double MoribdlyObeseFemaleLLN = 0.58;
        
    }
}