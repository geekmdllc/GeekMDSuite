using GeekMDSuite.Tools;

namespace GeekMDSuite.Models
{
    public class Waist : ILengthMeasurement
    {
        private double _inches;

        public Waist(double inches)
        {
            _inches = inches;
        }

        public double Inches => _inches;

        public double Centimeters => UnitConversion.InchesToCentimeters(Inches);

        public double Meters => UnitConversion.CentimetersToMeters(Centimeters);
    }
}