using Calc = GeekMDSuite.Calculations.BodyComposition;

namespace GeekMDSuite.Interpretation
{
    public static class VisceralFat
    {
        
        public static VisceralFatClassification VisceralFatFlag (double visceralFat) => ClassifyVisceralFat(visceralFat);
        
        private static VisceralFatClassification ClassifyVisceralFat(double visceralFat)
        {
            if (visceralFat > VisceralFatAreaUpperLimit * 1.5)
                return VisceralFatClassification.VeryElevated;
            if (visceralFat > VisceralFatAreaUpperLimit)
                return VisceralFatClassification.Elevated;
            return visceralFat > VisceralFatAreaUpperLimit * 0.5
                ? VisceralFatClassification.Acceptable
                : VisceralFatClassification.Excellent;
        }
        
        public static readonly double VisceralFatAreaUpperLimit = 100;        
    }
}