using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class VisceralFatInterpretation : IInterpretable
    {
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public static VisceralFatClassification Classification (double visceralFat) => ClassifyVisceralFat(visceralFat);
        
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