using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public class BodyComposition : IBodyComposition
    {
        internal BodyComposition(ILengthMeasurement heightInches, 
            ILengthMeasurement waistInches, 
            ILengthMeasurement hipsInches, 
            IMassMeasurement weightPounds)
        {
            Height = heightInches;
            Waist = waistInches;
            Hips = hipsInches;
            Weight = weightPounds;
        }

        private BodyComposition(double heightInches, double waistInches, double hipsInches, double weightPounds) 
            :this(LengthMeasurement.Create(heightInches), 
                LengthMeasurement.Create(waistInches), 
                LengthMeasurement.Create(hipsInches), 
                MassMeasurement.Create(weightPounds))
        {
        }
        
        public ILengthMeasurement Height { get; }
        public ILengthMeasurement Waist { get; }
        public ILengthMeasurement Hips { get; }
        public IMassMeasurement Weight { get; }

        internal static BodyComposition Build(double heightInches, double waistInches, double hipsInches,
            double weightPounds) => new BodyComposition(heightInches, waistInches, hipsInches, weightPounds);
    }
}