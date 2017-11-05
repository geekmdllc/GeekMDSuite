using Calc = GeekMDSuite.Calculations.BodyComposition;

namespace GeekMDSuite.Interpretation
{
    public static class VisceralFat
    {
        
        public static VisceralFatClassification VisceralFatFlag (double visceralFat) => ClassifyVisceralFat(visceralFat);
        
        private static VisceralFatClassification ClassifyVisceralFat(double visceralFat)
        {
            if (visceralFat > UpperLimitNormal * 1.5)
                return VisceralFatClassification.VeryElevated;
            if (visceralFat > UpperLimitNormal)
                return VisceralFatClassification.Elevated;
            return visceralFat > UpperLimitNormal * 0.5
                ? VisceralFatClassification.Acceptable
                : VisceralFatClassification.Excellent;
        }
        
        public static readonly double UpperLimitNormal = 100;        
    }
}