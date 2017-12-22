using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class PeripheralVisionInterpreation : IInterpretable<PeripheralVisionClassification>
    {
        private readonly PeripheralVision _peripheralVision;

        public PeripheralVisionInterpreation(PeripheralVision peripheralVision)
        {
            _peripheralVision = peripheralVision ?? throw new ArgumentNullException(nameof(peripheralVision));
        }

        public const int LowerLimitOfNormal = 70;
        public InterpretationText Interpretation => throw new NotImplementedException();
        public PeripheralVisionClassification Classification => Classify();
        public PeripheralVisionClassification Left => ClassifyLeft();
        public PeripheralVisionClassification Right => ClassifyRight();

        public override string ToString() => Classification.ToString();

        private PeripheralVisionClassification Classify() => _peripheralVision.Left < _peripheralVision.Right 
            ? ClassifyLeft() : ClassifyRight();

        private PeripheralVisionClassification ClassifyLeft() => ClassifySide(_peripheralVision.Left);

        private PeripheralVisionClassification ClassifyRight() => ClassifySide(_peripheralVision.Right);

        private static PeripheralVisionClassification ClassifySide(int side) => side >= LowerLimitOfNormal
            ? PeripheralVisionClassification.Normal : PeripheralVisionClassification.Narrow;
    }
}