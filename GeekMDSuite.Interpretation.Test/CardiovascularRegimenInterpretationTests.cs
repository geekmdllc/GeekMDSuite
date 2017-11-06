using GeekMDSuite.Common.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class CardiovascularRegimenInterpretationTests
    {
        
        [Fact]
        public void Calculate_GivenLowIntensityAnd150Minutes_ReturnsInsufficient()
        {
            var result = CardiovascularRegimenInterpretation.Calculate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.Low));
            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }
        
        [Fact]
        public void Calculate_GivenModerateIntensityAnd150Minutes_ReturnsAdequate()
        {
            var result = CardiovascularRegimenInterpretation.Calculate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.Moderate));
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Calculate_GivenHighIntensityAnd150Minutes_ReturnsAspirational()
        {
            var result = CardiovascularRegimenInterpretation.Calculate(
                new CardiovascularRegimen(3, 50, ExerciseIntensity.High));
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
    }
}