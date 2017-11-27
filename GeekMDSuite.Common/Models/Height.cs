using GeekMDSuite.Common.Tools;

namespace GeekMDSuite.Common.Models
{
    public class Height : ILengthMeasurement 
    {
        private double _inches;

        public Height(double inches)
        {
            _inches = inches;
        }

        public double Inches => _inches;

        public double Centimeters => UnitConversion.InchesToCentimeters(Inches);

        public double Meters => UnitConversion.CentimetersToMeters(Centimeters);
    }
}