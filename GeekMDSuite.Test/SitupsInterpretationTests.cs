using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SitupsInterpretationTests
    {
        [Theory]
        [InlineData(16, 32, GenderIdentity.Male, FitnessClassification.VeryPoor)]
        [InlineData(22, 32, GenderIdentity.Male, FitnessClassification.Poor)]
        [InlineData(26, 32, GenderIdentity.Male, FitnessClassification.BelowAverage)]
        [InlineData(29, 32, GenderIdentity.Male, FitnessClassification.Average)]
        [InlineData(34, 32, GenderIdentity.Male, FitnessClassification.AboveAverage)]
        [InlineData(40, 32, GenderIdentity.Male, FitnessClassification.Good)]
        [InlineData(42, 32, GenderIdentity.Male, FitnessClassification.Excellent)]
        [InlineData(6, 32, GenderIdentity.Female, FitnessClassification.VeryPoor)]
        [InlineData(14, 32, GenderIdentity.Female, FitnessClassification.Poor)]
        [InlineData(18, 32, GenderIdentity.Female, FitnessClassification.BelowAverage)]
        [InlineData(22, 32, GenderIdentity.Female, FitnessClassification.Average)]
        [InlineData(26, 32, GenderIdentity.Female, FitnessClassification.AboveAverage)]
        [InlineData(32, 32, GenderIdentity.Female, FitnessClassification.Good)]
        [InlineData(34, 32, GenderIdentity.Female, FitnessClassification.Excellent)]
        public void Classification_GivenPatientAndData_ReturnsCorrectClassifiation(int distance, int age,
            GenderIdentity genderIdentity, FitnessClassification expectedFitnessClassification)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(genderIdentity);

            var situps = Situps.Build(distance);
            
            var classification = new SitupsInterpretation(situps, _patient).Classification;
            
            Assert.Equal(expectedFitnessClassification, classification);
        }

        [Fact]
        public void NullSitAndReach_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SitupsInterpretation(null, new Mock<IPatient>().Object));
        }
        
        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SitupsInterpretation(new Mock<IMuscularStrengthTest>().Object, null));
        }

        public SitupsInterpretationTests()
        {
            _patient = new Patient();
        }
        private readonly Patient _patient;
    }
}