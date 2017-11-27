namespace GeekMDSuite.Common.Tools
{
    public class LengthMeasurement
    {
        public LengthMeasurement(double inches)
        {
            Inches = inches;
        }

        public double Inches { get; }
        public double Centimeters => UnitConversion.InchesToCentimeters(Inches);
        public double Meters => UnitConversion.CentimetersToMeters(Centimeters);
    }
}