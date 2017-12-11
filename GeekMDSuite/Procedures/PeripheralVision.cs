using System;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public class PeripheralVision
    {
        public PeripheralVision(int degrees)
        {
            Degrees = degrees;
        }

        public int Degrees { get; }
    }
    
    public class PeripheralVisionInterpreation : IInterpretable<PeripheralVisionClassification>
    {
        public static readonly int LowerLimitOfNormal = 70;
        public InterpretationText Interpretation => throw new NotImplementedException();
        public PeripheralVisionClassification Classification => throw new NotImplementedException();
    }

    public enum PeripheralVisionClassification
    {
        Normal,
        Narrow
    }
}