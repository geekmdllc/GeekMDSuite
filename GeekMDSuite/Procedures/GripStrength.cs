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

        public IMassMeasurement Left { get; }
        public IMassMeasurement Right { get; }
    }
}