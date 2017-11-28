using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PercentBodyFatTest
    {
        [Fact]
        public void Interpret_GivenMaleWith5Percent_ReturnsUnderFat()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Male, 5);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);
            
            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenMaleWith13point9Percent_ReturnsAthletic()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Male, 13.9);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith15Percent_ReturnsFitness()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Male, 15);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith20Percent_ReturnsAcceptable()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Male, 20);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith30Percent_ReturnsOverFat()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Male, 30);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith13Percent_ReturnsUnderFat()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Female, 13);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith20point9Percent_ReturnsAthletic()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Female, 20.9);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith24point9Percent_ReturnsFitness()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Female, 24.9);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith30Percent_ReturnsAcceptable()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Female, 30);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);
            
            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith35Percent_ReturnsOverFat()
        {
            var mockPatient = GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity.Female, 35);
            
            var result = PercentBodyFat.Interpret(mockPatient.Object);

            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }

        private static Mock<IPatient> GenerateMockPatientByGenderAndPercentBodyFat(GenderIdentity gender,
            double percentBodyFat)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(gender);
            mockPatient.Setup(p => p.PercentBodyFat).Returns(percentBodyFat);

            return mockPatient;
        }
    }
}