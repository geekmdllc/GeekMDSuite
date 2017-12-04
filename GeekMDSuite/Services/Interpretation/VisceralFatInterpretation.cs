using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class VisceralFatInterpretation : IInterpretable<VisceralFatClassification>
    {
        public VisceralFatInterpretation(IBodyCompositionExpanded bodyCompositionExpanded)
        {
            _visceralFat = bodyCompositionExpanded.VisceralFat;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public VisceralFatClassification Classification => ClassifyVisceralFat();

        private readonly double _visceralFat;
        
        private VisceralFatClassification ClassifyVisceralFat()
        {           
            if (_visceralFat > UpperLimitNormal * 1.5)
                return VisceralFatClassification.VeryElevated;
            if (_visceralFat > UpperLimitNormal)
                return VisceralFatClassification.Elevated;
            return _visceralFat > UpperLimitNormal * 0.5
                ? VisceralFatClassification.Acceptable
                : VisceralFatClassification.Excellent;
        }
        
        public static readonly double UpperLimitNormal = 100;
    }
}