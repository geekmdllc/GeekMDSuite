using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Interpretation.PatientActivities;
using Xunit;

namespace GeekMDSuite.Test
{
    public class ResistanceRegimenInterpretationTests
    {
        [Theory]
        [InlineData(45,120,2,ExerciseIntensity.Low,ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,121,2,ExerciseIntensity.Moderate,ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,120,1,ExerciseIntensity.High,ExerciseRegimenClassification.Insufficient )]
        [InlineData(44,120,2,ExerciseIntensity.Low,ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,75,3,ExerciseIntensity.Moderate,ExerciseRegimenClassification.Adequate )]
        [InlineData(75,90,2,ExerciseIntensity.Moderate,ExerciseRegimenClassification.Adequate )] 
        [InlineData(75,90,2,ExerciseIntensity.High,ExerciseRegimenClassification.Aspirational )] 
        public void Classification_GivenValues_ReturnsCorrectClassification(int sessionDuration, int secondsRest, 
            int sessionsPerWeek, ExerciseIntensity intensity, ExerciseRegimenClassification expectedClassification)
        {
            var regimen = new ResistanceRegimenBuilder()
                .SetAverageSessionDuration(sessionDuration)
                .SetIntensity(intensity)
                .SetSecondsRestDurationPerSet(secondsRest)
                .SetSessionsPerWeek(sessionsPerWeek)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .ConfirmPushingMovementsPerformed()
                .ConfirmRepetitionsToNearFailure()
                .Build();
            
            var classification = new ResistanceRegimenInterpretation(regimen).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }
        
        [Fact]
        public void Classification_GivenAdequateExceptInsufficientFeatures_ReturnsInsufficent()
        {
            var regimen = new ResistanceRegimenBuilder()
                .SetAverageSessionDuration(60)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(5)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .Build();
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;

            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }

        [Fact]
        public void NullRegimen_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ResistanceRegimenInterpretation(null));
        }
    }
}