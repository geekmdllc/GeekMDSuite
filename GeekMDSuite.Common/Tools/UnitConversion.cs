namespace GeekMDSuite.Common.Tools
{
    public static class UnitConversion
    {
        public static double LbsToKilograms(double pounds) => pounds * 2.2;

        public static double KilogramsToGrams(double kilograms) => kilograms * 100;

        public static double InchesToCentimeters(double inches) => inches * 2.54;

        public static double CentimetersToMeters(double centimeters) => centimeters * 100;
    }
}