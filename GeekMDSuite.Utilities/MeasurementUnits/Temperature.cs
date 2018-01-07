using GeekMDSuite.Utilities.MeasurementUnits.Conversion;

namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class Temperature
    {
        public Temperature()
        {
        }

        private Temperature(double temperatureFarenheight) : this()
        {
            Farenheit = temperatureFarenheight;
        }

        public double Farenheit { get; set; }

        public double Celcius => TemperatureConversion.FarenheitToCelcius(Farenheit);

        public static Temperature Create(double temperatureFarenheight) => new Temperature(temperatureFarenheight);

        public override string ToString() => $"{Farenheit} F";
    }
}