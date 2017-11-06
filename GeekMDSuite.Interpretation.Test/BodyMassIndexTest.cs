using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BodyMassIndexTest
    {
        [Fact]
        public void Interpret_GivenAsianWithBmi23point2_ReturnsOverweight()
        {
            var result = BodyMassIndex.Interpret(Races.Asian, 23.2);
            Assert.Equal(BodyMassIndexCategories.OverWeight, result);
        }

        [Fact]
        public void Interpret_GivenAsianWithBmi27point9_ReturnsObesityClass1()
        {
            var result = BodyMassIndex.Interpret(Races.Asian, 27.9);
            Assert.Equal(BodyMassIndexCategories.ObesityClass1, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var result = BodyMassIndex.Interpret(Races.Asian, 35.2);
            Assert.Equal(BodyMassIndexCategories.ObesityClass2, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi23point2_ReturnsNormalWeight()
        {
            var result = BodyMassIndex.Interpret(Races.White, 23.2);
            Assert.Equal(BodyMassIndexCategories.NormalWeight, result);
        }

        [Fact]
        public void Interpret_GivenNonAsianWithBmi27point9_ReturnsOverweight()
        {
            var result = BodyMassIndex.Interpret(Races.BlackOrAfricanAmerican, 27.9);
            Assert.Equal(BodyMassIndexCategories.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var result = BodyMassIndex.Interpret(Races.BlackOrAfricanAmerican, 35.2);
            Assert.Equal(BodyMassIndexCategories.ObesityClass2, result);
        }
    }
}