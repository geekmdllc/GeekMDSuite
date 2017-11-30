using Xunit;

namespace GeekMDSuite.Test
{
    public class StretchingRegimenInterpretationTests
    {
        
        [Fact]
        public void Calculate_GivenLowIntensityAnd150Minutes_ReturnsInsufficient()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 50, ExerciseIntensity.Low)).Classify();
            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }
        
        [Fact]
        public void Calculate_GivenModerateIntensityAnd7Minutes_ReturnsAdequate()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)).Classify();
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Calculate_GivenHighIntensityAnd20Minutes_ReturnsAspirational()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 20, ExerciseIntensity.High)).Classify();
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
        
        [Fact]
        public void RegimenPercentOfGoalAchieved_GivenHighIntensityStretchingAnd40Minutes_Returns200()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(4, 10, ExerciseIntensity.High)).DurationPercentOfGoalAchieved;
            
            Assert.Equal(200, result);
        }

        [Fact]
        public void IntensityIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)).IntensityIsAdequate;
            
            Assert.True(result);
        }

        [Fact]
        public void DurationIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)).IntensityIsAdequate;
            
            Assert.True(result);
        }
        
        [Fact]
        public void RegimenIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = new StretchingRegimen(new ExerciseRegimenBase(3, 30, ExerciseIntensity.Moderate)).RegimenIsAdequate;
            
            Assert.True(result);
        }
    }
}