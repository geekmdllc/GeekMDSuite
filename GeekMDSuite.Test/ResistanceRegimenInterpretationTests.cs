using System.Collections.Generic;
using GeekMDSuite.PatientActivities;
using Xunit;

namespace GeekMDSuite.Test
{
    public class ResistanceRegimenInterpretationTests
    {
        [Fact]
        public void Interpret_GivenAllAdequateValues_ReturnsAdequate()
        {
            var result = new ResistanceRegimen(
                    new ExerciseRegimenBase(3,45,ExerciseIntensity.High),
                    60,
                    new List<ResistenceRegimenFeatures>
                    {
                        ResistenceRegimenFeatures.LowerBodyTrained, 
                        ResistenceRegimenFeatures.PullingMovementsPerformed, 
                        ResistenceRegimenFeatures.PushingMovementsPerformed,
                        ResistenceRegimenFeatures.UpperBodyTrained,
                        ResistenceRegimenFeatures.RepetitionsToNearFailure
                    }).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Interpret_GivenAspirationalDurationAndAdequateElse_ReturnsAspirational()
        {
            var result = new ResistanceRegimen(
                    new ExerciseRegimenBase(3,90,ExerciseIntensity.High),
                    60,
                    new List<ResistenceRegimenFeatures>
                    {
                        ResistenceRegimenFeatures.LowerBodyTrained, 
                        ResistenceRegimenFeatures.PullingMovementsPerformed, 
                        ResistenceRegimenFeatures.PushingMovementsPerformed,
                        ResistenceRegimenFeatures.UpperBodyTrained,
                        ResistenceRegimenFeatures.RepetitionsToNearFailure
                    }).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
        
        [Fact]
        public void Interpret_GivenAdequateExceptInsufficientFeatures_ReturnsInsufficent()
        {
            var result = new ResistanceRegimen(
                    new ExerciseRegimenBase(3,90,ExerciseIntensity.High),
                    60,
                    new List<ResistenceRegimenFeatures>
                    {
                        ResistenceRegimenFeatures.PushingMovementsPerformed,
                        ResistenceRegimenFeatures.UpperBodyTrained,
                        ResistenceRegimenFeatures.RepetitionsToNearFailure
                    }).Classification;
            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }
    }
}