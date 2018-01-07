namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class Height : LengthMeasurement
    {
        private Height(double inches) : base(inches)
        {
        }

        public Height()
        {
        }

        public static Height Build(double inches)
        {
            return new Height(inches);
        }
    }
}