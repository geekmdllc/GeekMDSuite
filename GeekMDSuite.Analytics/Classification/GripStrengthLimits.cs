using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.Core.Tools.MeasurementUnits;
using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthLimits : IGripStrengthLimits
    {
        internal static GripStrengthLimits BuildFromKilogramsInput(double lower, double upper) 
            => BuildFromPoundsInput(MassConversion.KilogramsToLbs(lower), MassConversion.KilogramsToLbs(upper));
        
        internal static GripStrengthLimits BuildFromPoundsInput(double lower, double upper) 
            => new GripStrengthLimits(lower, upper);

        private GripStrengthLimits(double lowerPounds, double upperPounds)
            : this((IMassMeasurement) GripMeasurement.Build(lowerPounds), GripMeasurement.Build(upperPounds))
        {
        }
        
        private GripStrengthLimits(IMassMeasurement lower, IMassMeasurement upper)
        {
            LowerLimitOfNormal = lower ?? throw new ArgumentNullException(nameof(lower));
            UpperLimitOfNormal = upper ?? throw new ArgumentNullException(nameof(upper));
        }

        public IMassMeasurement LowerLimitOfNormal { get; }
        public IMassMeasurement UpperLimitOfNormal { get; }
    }
}