using System;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public class OcularPressure
    {
        public OcularPressure(int pressure)
        {
            Pressure = pressure;
        }

        public int Pressure { get; }
        
        public static readonly int UpperLimitOfNormal = 22;
    }
    
    public class OcularPressureInterpretation : IInterpretable<OcularPressureClassification>
    {
        public static readonly int PeripheralVisionLowerLimitOfNormal = 70;
        public InterpretationText Interpretation => throw new NotImplementedException();
        public OcularPressureClassification Classification => throw new NotImplementedException();
    }

    public enum OcularPressureClassification
    {
        Normal,
        MildElevation,
        Elevation,
        ModerateElevation,
        SevereElevation
    }
}