namespace GeekMDSuite.Core.Tools.MeasurementUnits.Conversion
{
    public static class LengthConversion
    {
        public static double InchesToCentimeters(double inches)
        {
            return inches * 2.54;
        }

        public static double CentimetersToInches(double centimeters)
        {
            return centimeters / 2.54;
        }

        public static double CentimetersToMeters(double centimeters)
        {
            return centimeters / 100;
        }
    }
}