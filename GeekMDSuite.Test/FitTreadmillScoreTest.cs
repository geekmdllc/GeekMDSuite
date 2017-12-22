using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Fitness;
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
        public void Value_GivenTreadmillAndPatientData_ReturnsCorrectValue(GenderIdentity genderIdentity, int age, 
            int maxHeartRate, double minutes, double seconds, double expectedScore)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(age);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var fitScore = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, mockPatient.Object).Value;
            
            Assert.InRange(fitScore, expectedScore - 0.001, expectedScore + 0.001);
        }
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, 3)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, 11)]
        public void TenYearMortality_GivenTreadmillAndPatientData_ReturnsCorrectTenYearMortality(GenderIdentity genderIdentity, int age, 
            int maxHeartRate, double minutes, double seconds, int expectedTenYearMortality)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(age);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var tenYearMortality = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, mockPatient.Object).TenYearMortality;
            
            Assert.Equal(expectedTenYearMortality, tenYearMortality);
        }
        [Theory]
        [InlineData(GenderIdentity.Female, 63, 165, 12, 00, FitTreadmillScoreMortality.LowRisk)]
        [InlineData(GenderIdentity.Male, 63, 165, 12, 00, FitTreadmillScoreMortality.ModerateRisk)]
        public void Classification_GivenTreadmillAndPatientData_ReturnsCorrectClassification(GenderIdentity genderIdentity, int age, 
            int maxHeartRate, double minutes, double seconds, FitTreadmillScoreMortality expectedClassification)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(age);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            var mockTreadmillStressTest = new Mock<ITreadmillExerciseStressTest>();
            mockTreadmillStressTest.Setup(tmst => tmst.MaximumHeartRate).Returns(maxHeartRate);
            mockTreadmillStressTest.Setup(tmst => tmst.Time).Returns(new TimeDuration(minutes, seconds));
            
            var classification = new FitTreadmillScoreInterpretation(mockTreadmillStressTest.Object, mockPatient.Object).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }
    }
}