using System.Collections.Generic;
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
            var baseRegimen = new ExerciseRegimenParameters(3, 45, ExerciseIntensity.High);
            var features = new List<ResistenceRegimenFeatures>()
            {
                ResistenceRegimenFeatures.LowerBodyTrained,
                ResistenceRegimenFeatures.PullingMovementsPerformed,
                ResistenceRegimenFeatures.PushingMovementsPerformed,
                ResistenceRegimenFeatures.UpperBodyTrained,
                ResistenceRegimenFeatures.RepetitionsToNearFailure
            };
            var regimen = new ResistanceRegimen(baseRegimen, 60, features);
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Interpret_GivenAspirationalDurationAndAdequateElse_ReturnsAspirational()
        {
            var baseRegimen = new ExerciseRegimenParameters(3, 90, ExerciseIntensity.High);
            var features = new List<ResistenceRegimenFeatures>()
            {
                ResistenceRegimenFeatures.LowerBodyTrained,
                ResistenceRegimenFeatures.PullingMovementsPerformed,
                ResistenceRegimenFeatures.PushingMovementsPerformed,
                ResistenceRegimenFeatures.UpperBodyTrained,
                ResistenceRegimenFeatures.RepetitionsToNearFailure
            };
            var regimen = new ResistanceRegimen(baseRegimen, 60, features);
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
        
        [Fact]
        public void Interpret_GivenAdequateExceptInsufficientFeatures_ReturnsInsufficent()
        {
            var baseRegimen = new ExerciseRegimenParameters(3, 90, ExerciseIntensity.High);
            var features = new List<ResistenceRegimenFeatures>()
            {
                ResistenceRegimenFeatures.PushingMovementsPerformed,
                ResistenceRegimenFeatures.UpperBodyTrained,
                ResistenceRegimenFeatures.RepetitionsToNearFailure
            };
            var regimen = new ResistanceRegimen(baseRegimen, 60, features);
            
            var result = new ResistanceRegimenInterpretation(regimen).Classification;

            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }
    }
}