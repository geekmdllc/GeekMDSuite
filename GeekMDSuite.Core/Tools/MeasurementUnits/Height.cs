namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class Height : LengthMeasurement
    {
        private Height(double inches) : base(inches)
        {
        }

        protected internal Height()
        {
            
        }
        
        public static Height Build(double inches) => new Height(inches);
    }
}