using System;
using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.PatientActivities;
using Xunit;
using ExerciseRegimenClassification = GeekMDSuite.Core.PatientActivities.ExerciseRegimenClassification;

namespace GeekMDSuite.Analytics.UnitTests.Classification.PatientActivities
{
    public class ResistanceRegimenInterpretationTests
    {
        [Theory]
        [InlineData(45,120,2,ExerciseIntensity.Low,Core.PatientActivities.ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,120,2,ExerciseIntensity.Moderate,Core.PatientActivities.ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,120,1,ExerciseIntensity.High,Core.PatientActivities.ExerciseRegimenClassification.Insufficient )]
        [InlineData(44,120,2,ExerciseIntensity.Low,Core.PatientActivities.ExerciseRegimenClassification.Insufficient )]
        [InlineData(45,75,3,ExerciseIntensity.Moderate,Core.PatientActivities.ExerciseRegimenClassification.Adequate )]
        [InlineData(75,90,2,ExerciseIntensity.Moderate,Core.PatientActivities.ExerciseRegimenClassification.Adequate )] 
        [InlineData(90,90,2,ExerciseIntensity.High,Core.PatientActivities.ExerciseRegimenClassification.Aspirational )] 
        [InlineData(120,90,2,ExerciseIntensity.Moderate,Core.PatientActivities.ExerciseRegimenClassification.Aspirational )] 
        public void Classification_GivenSatisfactoryFeaturesAndDifferentValues_ReturnsCorrectClassification(int sessionDuration, int secondsRest, 
            int sessionsPerWeek, ExerciseIntensity intensity, Core.PatientActivities.ExerciseRegimenClassification expectedClassification)
        {
            var regimen = ResistanceRegimenBuilder
                .Initialize()
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
            
            var classification = new ResistanceRegimenClassification(regimen).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }
        
        [Fact]
        public void Classification_GivenAdequateValuesAndInsufficientFeatures_ReturnsInsufficent()
        {
            var regimen = ResistanceRegimenBuilder
                .Initialize()
                .SetAverageSessionDuration(60)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(5)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .Build();
            
            var result = new ResistanceRegimenClassification(regimen).Classification;

            Assert.Equal(Core.PatientActivities.ExerciseRegimenClassification.Insufficient, result);
        }

        [Fact]
        public void NullRegimen_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ResistanceRegimenClassification(null));
        }
    }
}