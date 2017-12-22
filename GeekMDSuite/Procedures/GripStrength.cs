using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class GripStrength : IGripStrength
    {
        private GripStrength(IMassMeasurement left, IMassMeasurement right)
        {
            Left = left;
            Right = right;
        }

        private GripStrength(double left, double right) 
            : this(GripMeasurement.Build(left), GripMeasurement.Build(right))
        {  }

        public IMassMeasurement Left { get; }
        public IMassMeasurement Right { get; }

        public static GripStrength Build(double leftPounds, double rightPounds) => new GripStrength(leftPounds, rightPounds);

        public override string ToString() => $"Left: {Left} Right: {Right}";
    }
}