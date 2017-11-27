using System;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Calculations
{
    public static class BodyComposition
    {
        public static double BodyMassIndexCalculation(IPatient patient) => 
            patient.BodyWeight.Kilograms / Math.Pow(patient.Height.Meters, 2);

        public static double WaistToHeightRatio(IPatient patient) => 
            patient.Waist.Centimeters / patient.Height.Centimeters;
    }
}