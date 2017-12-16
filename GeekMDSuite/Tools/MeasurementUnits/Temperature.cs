using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class Temperature : ITemperature
    {
        internal Temperature(double temperatureFarenheight)
        {
            Farenheit = temperatureFarenheight;
        }
        public double Farenheit { get; }

        public double Celcius => TemperatureConversion.FarenheitToCelcius(Farenheit);
        
        public static Temperature Create(double temperatureFarenheight) =>
            new Temperature(temperatureFarenheight);
    }
}