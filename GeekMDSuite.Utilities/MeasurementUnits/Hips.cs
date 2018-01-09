namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class Hips : LengthMeasurement
    {
        private Hips(double inches) : base(inches)
        {
        }

        public Hips()
        {
        }

        public static Hips Build(double inches)
        {
            return new Hips(inches);
        }
    }
}