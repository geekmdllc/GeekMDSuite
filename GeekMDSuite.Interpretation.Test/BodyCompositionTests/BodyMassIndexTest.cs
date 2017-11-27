using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using GeekMDSuite.Interpretation.BodyComposition;
using Xunit;

namespace GeekMDSuite.Interpretation.Test.BodyCompositionTests
{
    public class BodyMassIndexTest
    {
        [Fact]
        public void Interpret_GivenAsianWithBmi23point2_ReturnsOverweight()
        {
            var result = BodyMassIndex.Interpretation(Race.Asian, 23.2);
            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }

        [Fact]
        public void Interpret_GivenAsianWithBmi27point9_ReturnsObesityClass1()
        {
            var result = BodyMassIndex.Interpretation(Race.Asian, 27.9);
            Assert.Equal(BodyMassIndexCategory.ObesityClass1, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var result = BodyMassIndex.Interpretation(Race.Asian, 35.2);
            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi23point2_ReturnsNormalWeight()
        {
            var result = BodyMassIndex.Interpretation(Race.White, 23.2);
            Assert.Equal(BodyMassIndexCategory.NormalWeight, result);
        }

        [Fact]
        public void Interpret_GivenNonAsianWithBmi27point9_ReturnsOverweight()
        {
            var result = BodyMassIndex.Interpretation(Race.BlackOrAfricanAmerican, 27.9);
            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var result = BodyMassIndex.Interpretation(Race.BlackOrAfricanAmerican, 35.2);
            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }
    }
}