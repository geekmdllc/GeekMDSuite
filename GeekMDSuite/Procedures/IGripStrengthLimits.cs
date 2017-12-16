using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public interface IGripStrengthLimits
    {
        IMassMeasurement LowerLimitOfNormal { get; }
        IMassMeasurement UpperLimitOfNormal { get; }
    }
}