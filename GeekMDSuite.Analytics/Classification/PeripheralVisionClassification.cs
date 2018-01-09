using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PeripheralVisionClassification : IClassifiable<PeripheralVisionClassificationResult>
    {
        public const int LowerLimitOfNormal = 70;
        private readonly PeripheralVision _peripheralVision;

        public PeripheralVisionClassification(PeripheralVision peripheralVision)
        {
            _peripheralVision = peripheralVision ?? throw new ArgumentNullException(nameof(peripheralVision));
        }

        public PeripheralVisionClassificationResult Left => ClassifyLeft();
        public PeripheralVisionClassificationResult Right => ClassifyRight();
        public PeripheralVisionClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private PeripheralVisionClassificationResult Classify()
        {
            return _peripheralVision.Left < _peripheralVision.Right
                ? ClassifyLeft()
                : ClassifyRight();
        }

        private PeripheralVisionClassificationResult ClassifyLeft()
        {
            return ClassifySide(_peripheralVision.Left);
        }

        private PeripheralVisionClassificationResult ClassifyRight()
        {
            return ClassifySide(_peripheralVision.Right);
        }

        private static PeripheralVisionClassificationResult ClassifySide(int side)
        {
            return side >= LowerLimitOfNormal
                ? PeripheralVisionClassificationResult.Normal
                : PeripheralVisionClassificationResult.Narrow;
        }
    }
}