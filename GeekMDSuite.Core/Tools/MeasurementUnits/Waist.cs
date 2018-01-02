namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class Waist : LengthMeasurement
    {
        private Waist(double inches) : base(inches)  { }

        protected internal Waist()
        { }
        
        public static Waist Build(double inches) => new Waist(inches);
    }
}