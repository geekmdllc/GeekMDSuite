using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class GripStrength
    {
        public GripStrength(IMassMeasurement left, IMassMeasurement right)
        {
            Left = left;
            Right = right;
        }

        public GripStrength(double left, double right) 
            : this(GripMeasurement.Build(left), GripMeasurement.Build(right))
        {  }

        public IMassMeasurement Left { get; }
        public IMassMeasurement Right { get; }

        public static GripStrength Build(double left, double right) => new GripStrength(left, right);
    }
}