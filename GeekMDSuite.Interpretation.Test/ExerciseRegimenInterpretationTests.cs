using GeekMDSuite.Common.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class ExerciseRegimenInterpretationTests
    {
        [Fact]
        public void RegimenPercentOfGoalAchieved_GivenHighIntensityCardiovascularAnd150Minutes_Returns200()
        {
            var result =
                ExerciseRegimenInterpretation.RegimenPercentOfGoalAchieved(
                    new CardiovascularRegimen(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(200, result);
        }

        [Fact]
        public void IntensityIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var result = ExerciseRegimenInterpretation.IntensityIsAdequate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(result);
        }

        [Fact]
        public void DurationIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var result = ExerciseRegimenInterpretation.IntensityIsAdequate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(result);
        }
        
        [Fact]
        public void RegimenIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var result = ExerciseRegimenInterpretation.RegimenIsAdequate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(result);
        }

        [Fact]
        public void GoalMinutes_GivenHighIntensityCardiovascular_Returns75()
        {
            var result = ExerciseRegimenInterpretation.GoalMinutes(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(75, result);
        }
        
        [Fact]
        public void GoalMinutes_GivenHighIntensityResistance_Returns90()
        {
            var result = ExerciseRegimenInterpretation.GoalMinutes(
                new ResistanceRegimen(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(90, result);
        }
    }
}