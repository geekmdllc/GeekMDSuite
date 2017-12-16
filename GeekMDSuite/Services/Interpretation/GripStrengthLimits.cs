using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public class GripStrengthLimits : IGripStrengthLimits
    {
        public GripStrengthLimits(IMassMeasurement lower, IMassMeasurement upper)
        {
            LowerLimitOfNormal = lower;
            UpperLimitOfNormal = upper;
        }

        public IMassMeasurement LowerLimitOfNormal { get; }
        public IMassMeasurement UpperLimitOfNormal { get; }
    }
}