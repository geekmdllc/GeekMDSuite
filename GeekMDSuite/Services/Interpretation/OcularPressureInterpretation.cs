using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class OcularPressureInterpretation : IInterpretable<OcularPressureClassification>
    {
        public OcularPressureInterpretation(OcularPressure pressure)
        {
            _ocularPressure = pressure;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        public OcularPressureClassification Classification => Classify();
        public OcularPressureClassification Left => ClassifyLeft();
        public OcularPressureClassification Right => ClassifyRight();
        
        public static readonly int UpperLimitOfNormal = 21;

        private OcularPressureClassification Classify() => _ocularPressure.Left > _ocularPressure.Right 
            ? ClassifyLeft() : ClassifyRight();

        private OcularPressureClassification ClassifyLeft() => _ocularPressure.Left <= UpperLimitOfNormal
            ? OcularPressureClassification.Normal
            : OcularPressureClassification.OcularHypertension;

        private OcularPressureClassification ClassifyRight() => _ocularPressure.Right <= UpperLimitOfNormal
            ? OcularPressureClassification.Normal
            : OcularPressureClassification.OcularHypertension;

        private readonly OcularPressure _ocularPressure;
    }
}