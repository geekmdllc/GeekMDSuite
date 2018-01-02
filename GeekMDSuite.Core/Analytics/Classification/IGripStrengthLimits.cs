using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public interface IGripStrengthLimits
    {
        IMassMeasurement LowerLimitOfNormal { get; }
        IMassMeasurement UpperLimitOfNormal { get; }
    }
}