namespace GeekMDSuite.Common.Tools
{
    public class LengthMeasurement
    {
        public LengthMeasurement(double inches)
        {
            Inches = inches;
        }

        public double Inches { get; set; }
        public double Centimeters => Inches * 2.54;
    }
}