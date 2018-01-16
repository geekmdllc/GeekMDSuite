using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class OcularPressureClassification : IClassifiable<OcularPressureClassificationResult>
    {
        public static readonly int UpperLimitOfNormal = 21;

        private readonly OccularPressure _occularPressure;

        public OcularPressureClassification(OccularPressure pressure)
        {
            _occularPressure = pressure ?? throw new ArgumentNullException(nameof(pressure));
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
            return _occularPressure.Left > _occularPressure.Right
                ? ClassifyLeft()
                : ClassifyRight();
        }

        private OcularPressureClassificationResult ClassifyLeft()
        {
            return ClassifySide(_occularPressure.Left);
        }

        private OcularPressureClassificationResult ClassifyRight()
        {
            return ClassifySide(_occularPressure.Right);
        }

        private static OcularPressureClassificationResult ClassifySide(int side)
        {
            return side <= UpperLimitOfNormal
                ? OcularPressureClassificationResult.Normal
                : OcularPressureClassificationResult.OcularHypertension;
        }
    }
}