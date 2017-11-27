using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using GeekMDSuite.Interpretation.BodyComposition;
using Moq;
using Xunit;

namespace GeekMDSuite.Interpretation.Test.BodyCompositionTests
{
    public class BodyMassIndexTest
    {
        [Fact]
        public void Interpret_GivenAsianWithBmi23point2_ReturnsOverweight()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.Asian, 23.2);

            var result = new BodyMassIndex(mockPatient.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi27point9_ReturnsObesityClass1()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.Asian, 27.9);

            var result = new BodyMassIndex(mockPatient.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.ObesityClass1, result);
        }
        [Fact]
        public void Interpret_GivenAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.Asian, 35.2);

            var result = new BodyMassIndex(mockPatient.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi23point2_ReturnsNormalWeight()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.White, 23.2);

            var result = new BodyMassIndex(mockPatient.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.NormalWeight, result);
        }

        [Fact]
        public void Interpret_GivenNonAsianWithBmi27point9_ReturnsOverweight()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.BlackOrAfricanAmerican, 27.9);

            var result = new BodyMassIndex(mockPatient.Object).Classification;

            Assert.Equal(BodyMassIndexCategory.OverWeight, result);
        }
        [Fact]
        public void Interpret_GivenNonAsianWithBmi35point2_ReturnsObesityClass2()
        {
            var mockPatient = BuildMockPatientByRaceAndBmi(Race.BlackOrAfricanAmerican, 35.2);

            var result = new BodyMassIndex(mockPatient.Object).Classification;
            
            Assert.Equal(BodyMassIndexCategory.ObesityClass2, result);
        }
        
        private static Mock<IPatient> BuildMockPatientByRaceAndBmi(Race race, double bmi)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Race).Returns(race);
            mockPatient.Setup(p => p.Height.Meters).Returns(1);
            mockPatient.Setup(p => p.BodyWeight.Kilograms).Returns(bmi);
            return mockPatient;
        }
    }
}
