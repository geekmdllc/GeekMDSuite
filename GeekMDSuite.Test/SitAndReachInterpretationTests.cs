using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SitAndReachInterpretationTests
    {
        [Theory]
        [InlineData(-21, 32, GenderIdentity.Male, FitnessClassification.VeryPoor)]
        [InlineData(-9, 32, GenderIdentity.Male, FitnessClassification.Poor)]
        [InlineData(-1, 32, GenderIdentity.Male, FitnessClassification.BelowAverage)]
        [InlineData(5, 32, GenderIdentity.Male, FitnessClassification.Average)]
        [InlineData(16, 32, GenderIdentity.Male, FitnessClassification.AboveAverage)]
        [InlineData(27, 32, GenderIdentity.Male, FitnessClassification.Good)]
        [InlineData(29, 32, GenderIdentity.Male, FitnessClassification.Excellent)]
        [InlineData(-16, 32, GenderIdentity.Female, FitnessClassification.VeryPoor)]
        [InlineData(-8, 32, GenderIdentity.Female, FitnessClassification.Poor)]
        [InlineData(0, 32, GenderIdentity.Female, FitnessClassification.BelowAverage)]
        [InlineData(10, 32, GenderIdentity.Female, FitnessClassification.Average)]
        [InlineData(20, 32, GenderIdentity.Female, FitnessClassification.AboveAverage)]
        [InlineData(29, 32, GenderIdentity.Female, FitnessClassification.Good)]
        [InlineData(31, 32, GenderIdentity.Female, FitnessClassification.Excellent)]
        public void Classification_GivenPatientAndData_ReturnsCorrectClassifiation(int distance, int age,
            GenderIdentity genderIdentity, FitnessClassification expectedFitnessClassification)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(age);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            var sitAndReach = SitAndReach.Build(distance);
            
            var classification = new SitAndReachInterpretation(sitAndReach, mockPatient.Object).Classification;
            
            Assert.Equal(expectedFitnessClassification, classification);
        }

        [Fact]
        public void NullSitAndReach_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SitAndReachInterpretation(null, new Mock<IPatient>().Object));
        }
        
        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SitAndReachInterpretation(new Mock<IMuscularStrengthTest>().Object, null));
        }
    }
}