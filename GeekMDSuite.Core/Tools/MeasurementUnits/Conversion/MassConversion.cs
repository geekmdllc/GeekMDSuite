namespace GeekMDSuite.Core.Tools.MeasurementUnits.Conversion
{
    public static class MassConversion
    {
        public static double LbsToKilograms(double pounds) => pounds / 2.2;
        public static double KilogramsToLbs(double kilograms) => kilograms * 2.2;
        public static double KilogramsToGrams(double kilograms) => kilograms * 100;
    }
}