﻿using GeekMDSuite.Tools.Math;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public abstract class Temperature : ITemperature
    {
        public Temperature(double temperatureFarenheight)
        {
            Farenheit = temperatureFarenheight;
        }
        public double Farenheit { get; }

        public double Celcius => TemperatureConversion.FarenheitToCelcius(Farenheit);
    }
}