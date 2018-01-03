using System;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PeripheralVisionClassification : IClassifiable<PeripheralVisionClassificationResult>
    {
        private readonly PeripheralVision _peripheralVision;

        public PeripheralVisionClassification(PeripheralVision peripheralVision)
        {
            _peripheralVision = peripheralVision ?? throw new ArgumentNullException(nameof(peripheralVision));
        }

        public const int LowerLimitOfNormal = 70;
        public PeripheralVisionClassificationResult Classification => Classify();
        public PeripheralVisionClassificationResult Left => ClassifyLeft();
        public PeripheralVisionClassificationResult Right => ClassifyRight();

        public override string ToString() => Classification.ToString();

        private PeripheralVisionClassificationResult Classify() => _peripheralVision.Left < _peripheralVision.Right 
            ? ClassifyLeft() : ClassifyRight();

        private PeripheralVisionClassificationResult ClassifyLeft() => ClassifySide(_peripheralVision.Left);

        private PeripheralVisionClassificationResult ClassifyRight() => ClassifySide(_peripheralVision.Right);

        private static PeripheralVisionClassificationResult ClassifySide(int side) => side >= LowerLimitOfNormal
            ? PeripheralVisionClassificationResult.Normal : PeripheralVisionClassificationResult.Narrow;
    }
}