namespace GeekMDSuite.Calculations
{
    public static class HeartRatePredictedMaximum
    {
        public static double CalculateRevisited(double ageInYears)
        {
            return 208 - 0.7 * ageInYears;
        }

        public static double CalculateStandard(double ageInYears)
        {
            return 220 - ageInYears;
        }
    }
}