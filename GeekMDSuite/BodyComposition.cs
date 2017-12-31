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

        protected internal BodyComposition()
        {
            Height = new Height();
            Waist = new Waist();
            Hips = new Hips();
            Weight = new Weight();
        }

        private BodyComposition(double heightInches, double waistInches, double hipsInches, double weightPounds) 
            :this(LengthMeasurement.Build(heightInches), 
                LengthMeasurement.Build(waistInches), 
                LengthMeasurement.Build(hipsInches), 
                MassMeasurement.Build(weightPounds))
        {
        }
        
        public ILengthMeasurement Height { get; set; }
        public ILengthMeasurement Waist { get; set; }
        public ILengthMeasurement Hips { get; set; }
        public IMassMeasurement Weight { get; set; }

        internal static BodyComposition Build(double heightInches, double waistInches, double hipsInches,
            double weightPounds) => new BodyComposition(heightInches, waistInches, hipsInches, weightPounds);

        public override string ToString() => $"Height: {Height} Waist: {Waist} Hips: {Hips} Weight: {Weight}";
    }
}