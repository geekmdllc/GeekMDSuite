using GeekMDSuite.Common;
using GenderEval = GeekMDSuite.Common.Gender;

namespace GeekMDSuite.Interpretation
{
    public class WaistToHeightRatio
    {
        public Genders Gender { get; set; }
        public double Waist { get; set; }
        public double Height { get; set; }

        public WaistToHeightRatio(Genders gender, double height, double waist)
        {
            Gender = gender;
            Height = height;
            Waist = waist;
        }

        public double Result =>
            Calculations.BodyComposition.WaistToHeightRatio(Waist, Height);
        
        public WaistToHeightRatioCategorization WaistToHeighRatioFlag => CategorizeWaistToHeightRatio();
        
        private WaistToHeightRatioCategorization CategorizeWaistToHeightRatio()
        {
            
            var Slim = GenderEval.IsXy(Gender)
                ? SlimWaistToHeightLowerLimitMale
                : SlimWaistToHeightLowerLimitFemale;

            var Healthy = GenderEval.IsXy(Gender)
                ? HealthyWaistToHeightLowerLimitMale
                : HealthyWaistToHeightLowerLimitFemale;

            var Overweight = GenderEval.IsXy(Gender)
                ? OverweightWaistToHeightLowerLimitMale
                : OverweightWaistToHeightLowerLimitFemale;

            var VeryOverweight = GenderEval.IsXy(Gender)
                ? VeryOverweightWaistToHeightLowerLimitMale
                : VeryOverweightWaistToHeightLowerLimitFemale;

            var MorbidlyObese = GenderEval.IsXy(Gender)
                ? MorbidlyObeseWaistToHeightLowerLimitMale
                : MorbidlyObeseWaistToHeightLowerLimitFemale;
            
            if (Result < Slim)
                return WaistToHeightRatioCategorization.ExtremelySlim;
            if (Result < Healthy)
                return WaistToHeightRatioCategorization.Slim;
            if (Result < Overweight)
                return WaistToHeightRatioCategorization.Healthy;
            if (Result < VeryOverweight)
                return WaistToHeightRatioCategorization.Overweight;
            return Result < MorbidlyObese
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