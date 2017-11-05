namespace GeekMDSuite.Common
{
    public class LengthMeasurement
    {
        public double Inches { get; set; }
        public double Centimeters => Inches * 2.54;
    }
}