using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class Temperature : ITemperature
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
        
        public static Temperature Create(double temperatureFarenheight) =>
            new Temperature(temperatureFarenheight);

        public override string ToString()
        {
            return $"{Farenheit} F";
        }
    }
}