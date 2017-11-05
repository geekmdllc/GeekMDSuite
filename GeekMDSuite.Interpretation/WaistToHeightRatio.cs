using GeekMDSuite.Common;
using GenderEval = GeekMDSuite.Common.Gender;

namespace GeekMDSuite.Interpretation
{
    public static class WaistToHeightRatio
    {
        
        public static WaistToHeightRatioCategorization Interpret (Genders gender, double result) => CategorizeWaistToHeightRatio(gender, result);
        
        private  static WaistToHeightRatioCategorization CategorizeWaistToHeightRatio(Genders gender, double result)
        {
            
            var Slim = GenderEval.IsXy(gender) ? SlimWaistToHeightLowerLimitMale : SlimWaistToHeightLowerLimitFemale;
            var Healthy = GenderEval.IsXy(gender) ? HealthyWaistToHeightLowerLimitMale : HealthyWaistToHeightLowerLimitFemale;
            var Overweight = GenderEval.IsXy(gender) ? OverweightWaistToHeightLowerLimitMale : OverweightWaistToHeightLowerLimitFemale;
            var VeryOverweight = GenderEval.IsXy(gender) ? VeryOverweightWaistToHeightLowerLimitMale : VeryOverweightWaistToHeightLowerLimitFemale;
            var MorbidlyObese = GenderEval.IsXy(gender) ? MorbidlyObeseWaistToHeightLowerLimitMale : MorbidlyObeseWaistToHeightLowerLimitFemale;
            
            if (result < Slim)
                return WaistToHeightRatioCategorization.ExtremelySlim;
            if (result < Healthy)
                return WaistToHeightRatioCategorization.Slim;
            if (result < Overweight)
                return WaistToHeightRatioCategorization.Healthy;
            if (result < VeryOverweight)
                return WaistToHeightRatioCategorization.Overweight;
            return result < MorbidlyObese
                ? WaistToHeightRatioCategorization.VeryOverweight
                : WaistToHeightRatioCategorization.MorbidlyObese;
        }
        
        public static double SlimWaistToHeightLowerLimitMale = 0.34;
        public static double SlimWaistToHeightLowerLimitFemale = 0.34;
        public static double HealthyWaistToHeightLowerLimitMale = 0.43;
        public static double HealthyWaistToHeightLowerLimitFemale = 0.42;
        public static double OverweightWaistToHeightLowerLimitMale = 0.53;
        public static double OverweightWaistToHeightLowerLimitFemale = 0.49;
        public static double VeryOverweightWaistToHeightLowerLimitMale = 0.58;
        public static double VeryOverweightWaistToHeightLowerLimitFemale = 0.54;
        public static double MorbidlyObeseWaistToHeightLowerLimitMale = 0.63;
        public static double MorbidlyObeseWaistToHeightLowerLimitFemale = 0.58;
        
    }
}