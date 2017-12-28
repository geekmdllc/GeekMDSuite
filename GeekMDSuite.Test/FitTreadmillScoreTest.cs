using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.MeasurementUnits;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class FitTreadmillScoreTest
    {
        // PercentMaxHeartRate +  12 * MetabolicEquivalents - 4 *  Age + (female ? 43 : 0)
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, 62.9298271155596)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, -1.32731574158328)]
        public void Value_GivenTreadmillAndPatientData_ReturnsCorrectValue(GenderIdentity gender, int age, 
            int maxHeartRate, double minutes, double seconds, double expectedScore)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var fitScore = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, _patient).Value;
            
            Assert.InRange(fitScore, expectedScore - 0.001, expectedScore + 0.001);
        }
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, 3)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, 11)]
        public void TenYearMortality_GivenTreadmillAndPatientData_ReturnsCorrectTenYearMortality(GenderIdentity gender, int age, 
            int maxHeartRate, double minutes, double seconds, int expectedTenYearMortality)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var tenYearMortality = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, _patient).TenYearMortality;
            
            Assert.Equal(expectedTenYearMortality, tenYearMortality);
        }
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, FitTreadmillScoreMortality.LowRisk)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, FitTreadmillScoreMortality.ModerateRisk)]
        public void Classification_GivenTreadmillAndPatientData_ReturnsCorrectClassification(GenderIdentity gender, int age, 
            int maxHeartRate, double minutes, double seconds, FitTreadmillScoreMortality expectedClassification)
        {
            _patient.DateOfBirth = DateTime.Now.AddYears(-age);
            _patient.Gender = Gender.Build(gender);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var classification = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, _patient).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void NullTreadmillStressTest_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FitTreadmillScoreInterpretation(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new FitTreadmillScoreInterpretation(new Mock<ITreadmillExerciseStressTest>().Object, null));
        }

        public FitTreadmillScoreTest()
        {
            _patient = new Patient();
        }
        private Patient _patient;
    }
}