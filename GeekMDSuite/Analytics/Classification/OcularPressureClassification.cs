using System;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class OcularPressureClassification : IClassifiable<OcularPressureClassificationResult>
    {
        public OcularPressureClassification(IOcularPressure pressure)
        {
            _ocularPressure = pressure ?? throw new ArgumentNullException(nameof(pressure));
        }
        public InterpretationText InterpretationText => throw new NotImplementedException();
        public OcularPressureClassificationResult Classification => Classify();
        public OcularPressureClassificationResult Left => ClassifyLeft();
        public OcularPressureClassificationResult Right => ClassifyRight();
        
        public static readonly int UpperLimitOfNormal = 21;

        public override string ToString() => Classification.ToString();

        private OcularPressureClassificationResult Classify() => _ocularPressure.Left > _ocularPressure.Right 
            ? ClassifyLeft() : ClassifyRight();

        private OcularPressureClassificationResult ClassifyLeft() => ClassifySide(_ocularPressure.Left);

        private OcularPressureClassificationResult ClassifyRight() => ClassifySide(_ocularPressure.Right);
        
        private static OcularPressureClassificationResult ClassifySide(int side) => side <= UpperLimitOfNormal
            ? OcularPressureClassificationResult.Normal
            : OcularPressureClassificationResult.OcularHypertension;

        private readonly IOcularPressure _ocularPressure;
    }
}