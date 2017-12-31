﻿using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class MassMeasurement : IMassMeasurement
    {
        internal MassMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; set;  }

        public double Kilograms => MassConversion.LbsToKilograms(Pounds);

        public double Grams => MassConversion.KilogramsToGrams(Kilograms);

        public static MassMeasurement Create(double pounds) => new MassMeasurement(pounds);

        public override string ToString() => $"{Pounds} lbs";
    }
}