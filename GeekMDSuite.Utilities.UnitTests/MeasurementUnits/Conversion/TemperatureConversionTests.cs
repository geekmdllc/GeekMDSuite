using GeekMDSuite.Utilities.MeasurementUnits.Conversion;
using Xunit;

namespace GeekMDSuite.Utilities.UnitTests.MeasurementUnits.Conversion
{
    public class TemperatureConversionTests
    {
        [Fact]
        public void CelciusToFarenheight_PerformsCorrectConversion()
        {
            const double tempCelcius = 37.0;
            var tempFarenheit = TemperatureConversion.CelciusToFarenheight(tempCelcius);

            const double expected = 98.6;
            const double tolerance = 0.001;
            Assert.InRange(tempFarenheit, expected - tolerance, expected + tolerance);
        }

        [Fact]
        public void FarenheitToCelcius_PerformsCorrectConversion()
        {
            const double tempFarenheit = 98.6;
            var tempCelcius = TemperatureConversion.FarenheitToCelcius(tempFarenheit);

            const double tolerance = 0.001;
            const double expected = 37.0;
            Assert.InRange(tempCelcius, expected - tolerance, expected + tolerance);
        }
    }
}