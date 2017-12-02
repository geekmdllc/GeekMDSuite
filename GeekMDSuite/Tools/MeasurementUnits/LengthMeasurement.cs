using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class LengthMeasurement : ILengthMeasurement
    {
        public LengthMeasurement(double inches)
        {
            Inches = inches;
        }

        public double Inches { get; }

        public double Centimeters => LengthConversion.InchesToCentimeters(Inches);

        public double Meters => LengthConversion.CentimetersToMeters(Centimeters);
    }
}