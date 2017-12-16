using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public interface IGripStrengthLimits
    {
        IMassMeasurement LowerLimitOfNormal { get; }
        IMassMeasurement UpperLimitOfNormal { get; }
    }
}