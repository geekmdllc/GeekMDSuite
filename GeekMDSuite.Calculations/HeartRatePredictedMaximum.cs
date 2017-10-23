namespace GeekMDSuite.Calculations
{
    public static class HeartRatePredictedMaximum
    {
        public static double Revisited(double ageInYears)
        {
            return 208 - 0.7 * ageInYears;
        }

        public static double Standard(double ageInYears)
        {
            return 220 - ageInYears;
        }
    }
}