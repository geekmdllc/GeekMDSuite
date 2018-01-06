using System;

namespace GeekMDSuite.Analytics.Tools.BodyComposition
{
    public static class CalculateBodyMassIndex
    {
        public static double Calculate(double weightKilograms, double heightMeters)
        {
            return Math.Round(weightKilograms / Math.Pow(heightMeters, 2), 3);
        }
    }
}