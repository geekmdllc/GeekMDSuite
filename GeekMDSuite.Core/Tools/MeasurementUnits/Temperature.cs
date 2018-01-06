﻿using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class Temperature
    {
        protected internal Temperature()
        {
        }

        private Temperature(double temperatureFarenheight) : this()
        {
            Farenheit = temperatureFarenheight;
        }

        public double Farenheit { get; set; }

        public double Celcius => TemperatureConversion.FarenheitToCelcius(Farenheit);

        public static Temperature Create(double temperatureFarenheight)
        {
            return new Temperature(temperatureFarenheight);
        }

        public override string ToString()
        {
            return $"{Farenheit} F";
        }
    }
}