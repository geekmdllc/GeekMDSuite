namespace GeekMDSuite
{
    public class Waist : LengthMeasurement
    {
        public Waist(double inches) : base(inches)
        {
        }
    }
    
    public abstract class LengthMeasurement : ILengthMeasurement
    {
        private double _inches;

        public LengthMeasurement(double inches)
        {
            _inches = inches;
        }

        public double Inches => _inches;

        public double Centimeters => UnitConversion.InchesToCentimeters(Inches);

        public double Meters => UnitConversion.CentimetersToMeters(Centimeters);
    }
}