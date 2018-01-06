namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class Hips : LengthMeasurement
    {
        private Hips(double inches) : base(inches)
        {
        }

        protected internal Hips()
        {
        }

        public static Hips Build(double inches)
        {
            return new Hips(inches);
        }
    }
}