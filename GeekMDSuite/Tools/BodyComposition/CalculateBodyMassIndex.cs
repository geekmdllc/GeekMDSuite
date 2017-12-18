using System;

namespace GeekMDSuite.Tools.BodyComposition
{
    static internal class CalculateBodyMassIndex
    {
        public static double Calculate(double weightKilograms, double heightMeters) =>
            weightKilograms / Math.Pow(heightMeters, 2);
    }
}