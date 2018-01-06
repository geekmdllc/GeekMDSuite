using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Models
{
    public class BodyComposition
    {
        internal BodyComposition(Height heightInches, 
            Waist waistInches, 
            Hips hipsInches, 
            Weight weightPounds) : this()
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
            :this(Height.Build(heightInches), Waist.Build(waistInches), Hips.Build(hipsInches), Weight.Build(weightPounds) )
        {
        }
        
        public Height Height { get; set; }
        public Waist Waist { get; set; }
        public Hips Hips { get; set; }
        public Weight Weight { get; set; }

        internal static BodyComposition Build(double heightInches, double waistInches, double hipsInches,
            double weightPounds) => new BodyComposition(heightInches, waistInches, hipsInches, weightPounds);

        public override string ToString() => $"Height: {Height} Waist: {Waist} Hips: {Hips} Weight: {Weight}";
    }
}