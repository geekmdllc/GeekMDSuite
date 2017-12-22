using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public interface IGripStrength
    {
        IMassMeasurement Left { get; }
        IMassMeasurement Right { get; }
    }
}