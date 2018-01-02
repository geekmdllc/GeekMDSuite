namespace GeekMDSuite.Tools.Cardiology
{
    public static class PredictMaximumHeartRate
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