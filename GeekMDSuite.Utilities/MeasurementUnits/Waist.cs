namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class Waist : LengthMeasurement
    {
        private Waist(double inches) : base(inches)
        {
        }

        public Waist()
        {
        }

        public static Waist Build(double inches)
        {
            return new Waist(inches);
        }
    }
}