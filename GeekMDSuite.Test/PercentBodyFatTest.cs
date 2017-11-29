using Xunit;

namespace GeekMDSuite.Test
{
    public class PercentBodyFatTest
    {
        [Fact]
        public void Interpret_GivenMaleWith5Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFatInterpretation.Interpret(5, GenderIdentity.Male);
            
            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenMaleWith13point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFatInterpretation.Interpret(13.9, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith15Percent_ReturnsFitness()
        {
            var result = PercentBodyFatInterpretation.Interpret(15, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith20Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFatInterpretation.Interpret(20, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenMaleWith30Percent_ReturnsOverFat()
        {
            var result = PercentBodyFatInterpretation.Interpret(30, GenderIdentity.Male);

            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith13Percent_ReturnsUnderFat()
        {
            var result = PercentBodyFatInterpretation.Interpret(13, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.UnderFat, result);
        }
        [Fact]
        public void Interpret_GivenFemaleWith20point9Percent_ReturnsAthletic()
        {
            var result = PercentBodyFatInterpretation.Interpret(20.9, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.Athletic, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith24point9Percent_ReturnsFitness()
        {
            var result = PercentBodyFatInterpretation.Interpret(24.9, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.Fitness, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith30Percent_ReturnsAcceptable()
        {
            var result = PercentBodyFatInterpretation.Interpret(30, GenderIdentity.Female);
            
            Assert.Equal(PercentBodyFatClassification.Acceptable, result);
        }
        
        [Fact]
        public void Interpret_GivenFemaleWith35Percent_ReturnsOverFat()
        {
            var result = PercentBodyFatInterpretation.Interpret(35, GenderIdentity.Female);

            Assert.Equal(PercentBodyFatClassification.OverFat, result);
        }

    }
}