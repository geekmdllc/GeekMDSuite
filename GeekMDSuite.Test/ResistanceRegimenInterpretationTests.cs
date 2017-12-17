using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Interpretation.PatientActivities;
using Xunit;

namespace GeekMDSuite.Test
{
    public class ResistanceRegimenInterpretationTests
    {
        [Fact]
        public void Interpret_GivenAllAdequateValues_ReturnsAdequate()
        {
            var regimen = new ResistanceRegimenBuilder()
                .SetAverageSessionDuration(45)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(3)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .ConfirmPushingMovementsPerformed()
                .ConfirmRepetitionsToNearFailure()
                .Build();
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Interpret_GivenAspirationalDurationAndAdequateElse_ReturnsAspirational()
        {
            var regimen = new ResistanceRegimenBuilder()
                .SetAverageSessionDuration(60)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(5)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .ConfirmPushingMovementsPerformed()
                .ConfirmRepetitionsToNearFailure()
                .Build();
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
        
        [Fact]
        public void Interpret_GivenAdequateExceptInsufficientFeatures_ReturnsInsufficent()
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
    }
}