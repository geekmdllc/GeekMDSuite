namespace GeekMDSuite.Core.Tools.MeasurementUnits.Conversion
{
    public static class MassConversion
    {
        public static double LbsToKilograms(double pounds)
        {
            return pounds / 2.2;
        }

        public static double KilogramsToLbs(double kilograms)
        {
            return kilograms * 2.2;
        }

        public static double KilogramsToGrams(double kilograms)
        {
            return kilograms * 100;
        }
    }
}