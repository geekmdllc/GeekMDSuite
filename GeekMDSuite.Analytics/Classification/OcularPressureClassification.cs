using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class OcularPressureClassification : IClassifiable<OcularPressureClassificationResult>
    {
        public static readonly int UpperLimitOfNormal = 21;

        private readonly OcularPressure _ocularPressure;

        public OcularPressureClassification(OcularPressure pressure)
        {
            _ocularPressure = pressure ?? throw new ArgumentNullException(nameof(pressure));
        }

        public OcularPressureClassificationResult Left => ClassifyLeft();
        public OcularPressureClassificationResult Right => ClassifyRight();

        public OcularPressureClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private OcularPressureClassificationResult Classify()
        {
            return _ocularPressure.Left > _ocularPressure.Right
                ? ClassifyLeft()
                : ClassifyRight();
        }

        private OcularPressureClassificationResult ClassifyLeft()
        {
            return ClassifySide(_ocularPressure.Left);
        }

        private OcularPressureClassificationResult ClassifyRight()
        {
            return ClassifySide(_ocularPressure.Right);
        }

        private static OcularPressureClassificationResult ClassifySide(int side)
        {
            return side <= UpperLimitOfNormal
                ? OcularPressureClassificationResult.Normal
                : OcularPressureClassificationResult.OcularHypertension;
        }
    }
}