using System;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Calculations
{
    public static class BodyComposition
    {
        public static double BodyMassIndex(IPatient patient) => 
            patient.Weight.Kilograms / Math.Pow(patient.Height.Meters, 2);

        public static double WaistToHeightRatio(IPatient patient) => 
            patient.Waist.Centimeters / patient.Height.Centimeters;
    }
}