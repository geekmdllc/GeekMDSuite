using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Analytics.Classification.PatientActivities;
using Xunit;
using ExerciseRegimenClassification = GeekMDSuite.PatientActivities.ExerciseRegimenClassification;

namespace GeekMDSuite.UnitTests
{
    public class CardiovascularRegimenInterpretationInterpretationTests
    {
        [Theory]
        [InlineData(3, 50, ExerciseIntensity.Low, ExerciseRegimenClassification.Insufficient)]
        [InlineData(3, 50, ExerciseIntensity.Moderate, ExerciseRegimenClassification.Adequate)]
        [InlineData(3, 50, ExerciseIntensity.High, ExerciseRegimenClassification.Aspirational)]
        public void Classification_GivenIntensityAndDuration_ReturnsCorrectClassification(int sessionsPerWeek, 
            int minutesPerSession, ExerciseIntensity intensity, ExerciseRegimenClassification expectedClassification)
        {
            var regimen = new CardiovascularRegimenClassification(ExerciseRegimenParameters.Build(sessionsPerWeek, minutesPerSession, intensity));
            
            Assert.Equal(expectedClassification, regimen.Classification);
        }

        [Theory]
        [InlineData(3, 12.5, ExerciseIntensity.Low, 0)]
        [InlineData(3, 25, ExerciseIntensity.Low, 0)]
        [InlineData(3, 50, ExerciseIntensity.Low, 0)]
        [InlineData(3, 12.5, ExerciseIntensity.Moderate, 25)]
        [InlineData(3, 25, ExerciseIntensity.Moderate, 50)]
        [InlineData(3, 50, ExerciseIntensity.Moderate, 100)]
        [InlineData(3, 12.5, ExerciseIntensity.High, 50)]
        [InlineData(3, 25, ExerciseIntensity.High, 100)]
        [InlineData(3, 50, ExerciseIntensity.High, 200)]
        public void DurationPercentOfGoalAchieved_GivenIntensityAndDuration_ReturnsCorrectPercentOfGoal(double sessionsPerWeek, 
            double minutesPerSession, ExerciseIntensity intensity, double percentOfGoalAchieved)
        {
            var exerciseRegimenParameters = ExerciseRegimenParameters.Build(sessionsPerWeek, minutesPerSession, intensity);
            var regimen = new CardiovascularRegimenClassification(exerciseRegimenParameters);
            
            Assert.Equal(percentOfGoalAchieved, regimen.DurationPercentOfGoalAchieved);
        }

        [Theory]
        [InlineData(3, 12.5, ExerciseIntensity.Low, false)]
        [InlineData(3, 25, ExerciseIntensity.Low, false)]
        [InlineData(3, 50, ExerciseIntensity.Low, false)]
        [InlineData(3, 12.5, ExerciseIntensity.Moderate, false)]
        [InlineData(3, 25, ExerciseIntensity.Moderate, false)]
        [InlineData(3, 50, ExerciseIntensity.Moderate, true)]
        [InlineData(3, 12.5, ExerciseIntensity.High, false)]
        [InlineData(3, 25, ExerciseIntensity.High, true)]
        [InlineData(3, 50, ExerciseIntensity.High, true)]
        public void DurationIsAdequate_GivenGivenIntensityAndDuration_ReturnsCorrectBooleanValue(double sessionsPerWeek, 
            double minutesPerSession, ExerciseIntensity intensity, bool expectedAdequacy)
        {
            var exerciseRegimenParameters = ExerciseRegimenParameters.Build(sessionsPerWeek, minutesPerSession, intensity);
            var regimen = new CardiovascularRegimenClassification(exerciseRegimenParameters);
            
            Assert.Equal(expectedAdequacy, regimen.DurationIsAdequate);
        }
        
        [Theory]
        [InlineData(3, 12.5, ExerciseIntensity.Low, false)]
        [InlineData(3, 25, ExerciseIntensity.Low, false)]
        [InlineData(3, 50, ExerciseIntensity.Low, false)]
        [InlineData(3, 12.5, ExerciseIntensity.Moderate, false)]
        [InlineData(3, 25, ExerciseIntensity.Moderate, false)]
        [InlineData(3, 50, ExerciseIntensity.Moderate, true)]
        [InlineData(3, 12.5, ExerciseIntensity.High, false)]
        [InlineData(3, 25, ExerciseIntensity.High, true)]
        [InlineData(3, 50, ExerciseIntensity.High, true)]
        public void RegimenIsAdequate_GivenGivenIntensityAndDuration_ReturnsCorrectBooleanValue(double sessionsPerWeek, 
            double minutesPerSession, ExerciseIntensity intensity, bool expectedAdequacy)
        {
            var exerciseRegimenParameters = ExerciseRegimenParameters.Build(sessionsPerWeek, minutesPerSession, intensity);
            var regimen = new CardiovascularRegimenClassification(exerciseRegimenParameters);
            
            Assert.Equal(expectedAdequacy, regimen.DurationIsAdequate);
        }

        [Fact]
        public void NullExerciseRegimenParameters_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CardiovascularRegimenClassification(null));
        }
    }
}