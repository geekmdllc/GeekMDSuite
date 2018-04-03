using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class OccularPressureClassification : IClassifiable<OccularPressureClassificationResult>
    {
        public static readonly int UpperLimitOfNormal = 21;

        private readonly OccularPressure _occularPressure;

        public OccularPressureClassification(OccularPressure pressure)
        {
            _occularPressure = pressure ?? throw new ArgumentNullException(nameof(pressure));
        }

        public OccularPressureClassificationResult Left => ClassifyLeft();
        public OccularPressureClassificationResult Right => ClassifyRight();

        public OccularPressureClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private OccularPressureClassificationResult Classify()
        {
            return _occularPressure.Left > _occularPressure.Right
                ? ClassifyLeft()
                : ClassifyRight();
        }

        private OccularPressureClassificationResult ClassifyLeft()
        {
            return ClassifySide(_occularPressure.Left);
        }

        private OccularPressureClassificationResult ClassifyRight()
        {
            return ClassifySide(_occularPressure.Right);
        }

        private static OccularPressureClassificationResult ClassifySide(int side)
        {
            return side <= UpperLimitOfNormal
                ? OccularPressureClassificationResult.Normal
                : OccularPressureClassificationResult.OcularHypertension;
        }
    }
}