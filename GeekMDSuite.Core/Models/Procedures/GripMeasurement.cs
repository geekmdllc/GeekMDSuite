﻿using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class GripMeasurement : MassMeasurement
    {
        private GripMeasurement(double pounds) : base(pounds)
        {
            Pounds = pounds;
        }

        public GripMeasurement()
        {
            
        }

        public static GripMeasurement Build(double pounds) => new GripMeasurement(pounds);
    }
}