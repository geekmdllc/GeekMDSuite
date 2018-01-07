using GeekMDSuite.Utilities.MeasurementUnits.Conversion;

namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class LengthMeasurement
    {
        protected LengthMeasurement(double inches)
        {
            Inches = inches;
        }

        protected LengthMeasurement()
        {
        }

        public double Inches { get; set; }

        public double Centimeters => LengthConversion.InchesToCentimeters(Inches);

        public double Meters => LengthConversion.CentimetersToMeters(Centimeters);

        public override string ToString()
        {
            return $"{Inches} in";
        }
    }
}