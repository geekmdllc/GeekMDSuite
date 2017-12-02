using GeekMDSuite.PatientActivities;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CardiovascularRegimenInterpretationTests
    {
        
        [Fact]
        public void Calculate_GivenLowIntensityAnd150Minutes_ReturnsInsufficient()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50,ExerciseIntensity.Low));
            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, regimen.Classification);
        }
        
        [Fact]
        public void Calculate_GivenModerateIntensityAnd150Minutes_ReturnsAdequate()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.Moderate));
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, regimen.Classification);
        }
        
        [Fact]
        public void Calculate_GivenHighIntensityAnd150Minutes_ReturnsAspirational()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, regimen.Classification);
        }
        
        [Fact]
        public void RegimenPercentOfGoalAchieved_GivenHighIntensityCardiovascularAnd150Minutes_Returns200()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(200, regimen.DurationPercentOfGoalAchieved);
        }

        [Fact]
        public void IntensityIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(regimen.IntensityIsAdequate);
        }

        [Fact]
        public void DurationIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(regimen.DurationIsAdequate);
        }
        
        [Fact]
        public void RegimenIsAdequate_GivenModerateIntensityCardiovascularAnd150Minutes_ReturnsTrue()
        {
            var regimen = new CardiovascularRegimen(new ExerciseRegimenParameters(3, 50, ExerciseIntensity.Moderate));
            
            Assert.True(regimen.RegimenIsAdequate);
        }
    }
}