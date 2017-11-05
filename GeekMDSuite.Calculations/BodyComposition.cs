using System;
using Conversion = GeekMDSuite.Calculations.UnitConversion;

namespace GeekMDSuite.Calculations
{
    public static class BodyComposition
    {
        public static double BodyMassIndexCalculator(double weightLbs, double heightInches)
        {
            return Conversion.LbsToKilograms(weightLbs) /
                   Math.Pow(Conversion.InchesToCentimeters(heightInches), 2);
        }

        public static double WaistToHeightRatio(double waistInches, double heightInches)
        {
            return waistInches / heightInches;
        }
    }
}