using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Core.Tools.MeasurementUnits;
using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthLimits
    {
        internal static GripStrengthLimits BuildFromKilogramsInput(double lower, double upper) 
            => BuildFromPoundsInput(MassConversion.KilogramsToLbs(lower), MassConversion.KilogramsToLbs(upper));

        private static GripStrengthLimits BuildFromPoundsInput(double lower, double upper) 
            => new GripStrengthLimits(lower, upper);

        private GripStrengthLimits(double lowerPounds, double upperPounds)
            : this(GripMeasurement.Build(lowerPounds), GripMeasurement.Build(upperPounds))
        {
        }
        
        private GripStrengthLimits(MassMeasurement lower, MassMeasurement upper)
        {
            LowerLimitOfNormal = lower ?? throw new ArgumentNullException(nameof(lower));
            UpperLimitOfNormal = upper ?? throw new ArgumentNullException(nameof(upper));
        }

        public MassMeasurement LowerLimitOfNormal { get; }
        public MassMeasurement UpperLimitOfNormal { get; }
    }
}