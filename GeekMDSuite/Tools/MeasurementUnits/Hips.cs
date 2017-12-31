namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class Hips : LengthMeasurement
    {
        protected internal Hips(double inches) : base(inches)
        {
        }

        protected internal Hips()
        {
        }
        
        public static Hips Build(double inches) => new Hips(inches);
    }
}