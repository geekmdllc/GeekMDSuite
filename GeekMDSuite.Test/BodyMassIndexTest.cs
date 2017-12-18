using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class BodyMassIndexTest
    {
        [Fact]
        public void Interpret_GivenAsianWithBmi23point2_ReturnsOverweight()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(23.2);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _asian.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi27point9_ReturnsObesityClass1()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(27.9);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _asian.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.ObesityClass1, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(35.2);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _asian.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi23point2_ReturnsNormalWeight()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(23.2);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _white.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.NormalWeight, result);
        }

        [Fact]
        public void Interpret_GivenNonAsianWithBmi27point9_ReturnsOverweight()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(27.9);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _blackOrAfricanAmerican.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var mockBodyComposition = BuildMockBodyCompositionByBmi(35.2);

            var result = new BodyMassIndexInterpretation(mockBodyComposition.Object, _blackOrAfricanAmerican.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }

        private readonly Mock<IPatient> _asian = BuildMockPatient(Race.Asian);
        private readonly Mock<IPatient> _white = BuildMockPatient(Race.White);
        private readonly Mock<IPatient> _blackOrAfricanAmerican = BuildMockPatient(Race.BlackOrAfricanAmerican);
        
        private static Mock<IBodyComposition> BuildMockBodyCompositionByBmi(double bmi)
        {
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(bc => bc.Height.Meters).Returns(1);
            mockBodyComposition.Setup(bc => bc.Weight.Kilograms).Returns(bmi);
            return mockBodyComposition;
        }

        private static Mock<IPatient> BuildMockPatient(Race race)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Race).Returns(race);
            return mockPatient;
        }
        
    }
}
