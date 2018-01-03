using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Core.Tools.MeasurementUnits
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

        public override string ToString() => $"{Inches} in";
    }
}