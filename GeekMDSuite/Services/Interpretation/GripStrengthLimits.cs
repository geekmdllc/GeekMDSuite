using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools.MeasurementUnits;
using static GeekMDSuite.Tools.MeasurementUnits.Conversion.MassConversion;

namespace GeekMDSuite.Services.Interpretation
{
    public class GripStrengthLimits : IGripStrengthLimits
    {
        internal static GripStrengthLimits BuildFromKilogramsInput(double lower, double upper) 
            => BuildFromPoundsInput(KilogramsToLbs(lower), KilogramsToLbs(upper));
        
        internal static GripStrengthLimits BuildFromPoundsInput(double lower, double upper) 
            => new GripStrengthLimits(lower, upper);

        private GripStrengthLimits(double lowerPounds, double upperPounds)
            : this(GripMeasurement.Build(lowerPounds), GripMeasurement.Build(upperPounds))
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