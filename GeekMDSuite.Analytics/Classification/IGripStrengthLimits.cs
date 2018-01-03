using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Analytics.Classification
{
    public interface IGripStrengthLimits
    {
        IMassMeasurement LowerLimitOfNormal { get; }
        IMassMeasurement UpperLimitOfNormal { get; }
    }
}