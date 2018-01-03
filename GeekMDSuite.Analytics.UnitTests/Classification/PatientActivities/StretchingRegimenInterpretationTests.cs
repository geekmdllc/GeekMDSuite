using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.PatientActivities;
using Xunit;
using ExerciseRegimenClassification = GeekMDSuite.Core.PatientActivities.ExerciseRegimenClassification;

namespace GeekMDSuite.Analytics.UnitTests.Classification.PatientActivities
{
    public class StretchingRegimenInterpretationTests
    {
        [Theory]
        [InlineData(3,10,ExerciseIntensity.Low,ExerciseRegimenClassification.Insufficient)]
        [InlineData(3,10,ExerciseIntensity.Moderate,ExerciseRegimenClassification.Adequate)]
        [InlineData(3,20,ExerciseIntensity.High,ExerciseRegimenClassification.Aspirational)]
        [InlineData(3,50,ExerciseIntensity.Low,ExerciseRegimenClassification.Insufficient)]

        public void Classification_GivenValues_ReturnsCorrectClassification(double sessionsPerWeek, double minutesPerSession,
            ExerciseIntensity intensity, ExerciseRegimenClassification expectedExerciseRegimenClassification)
        {
            var classification = new StretchingRegimenClassification(
                ExerciseRegimenParameters.Build(sessionsPerWeek, minutesPerSession, intensity)).Classification;
            
            Assert.Equal(expectedExerciseRegimenClassification, classification);
        }
        
        [Fact]
        public void RegimenPercentOfGoalAchieved_GivenHighIntensityStretchingAnd40Minutes_Returns200()
        {
            var result = new StretchingRegimenClassification(ExerciseRegimenParameters.Build(4, 10, ExerciseIntensity.High)).DurationPercentOfGoalAchieved;
            
            Assert.Equal(200, result);
        }
        
        [Fact]
        public void IntensityIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimenClassification(ExerciseRegimenParameters.Build(3, 10, ExerciseIntensity.Moderate)).IntensityIsAdequate;
            
            Assert.True(result);
        }

        [Fact]
        public void DurationIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimenClassification(ExerciseRegimenParameters.Build(3, 10, ExerciseIntensity.Moderate)).IntensityIsAdequate;
            
            Assert.True(result);
        }
        
        [Fact]
        public void RegimenIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimenClassification(ExerciseRegimenParameters.Build(3, 30, ExerciseIntensity.Moderate)).RegimenIsAdequate;
            
            Assert.True(result);
        }
    }
}