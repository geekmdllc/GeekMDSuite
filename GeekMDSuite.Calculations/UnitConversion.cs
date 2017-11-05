namespace GeekMDSuite.Calculations
{
    public static class UnitConversion
    {
        public static double LbsToKilograms(double pounds)
        {
            return pounds / 2.2;
        }

        public static double InchesToCentimeters(double inches)
        {
            return inches * 2.54;
        }
    }
}