using GeekMDSuite;
using GeekMDSuite.Models;
using Xunit;
using Vo2Max = GeekMDSuite.Vo2Max;

namespace GeekMDSuite.Interpretation.Test.FitnessTests
{
    public class Vo2MaxTest
    {
        private double vo2Max = 45;
        private GenderIdentity male = GenderIdentity.NonBinaryXy;
        private GenderIdentity female = GenderIdentity.Female;
        private double age = 52;

        [Fact]
        public void Interpret_Given52yrMaleWithVo2Max45_ReturnsGoodFitnessClassification()
        {
            var vo2MaxInterp = Vo2Max.Interpret(vo2Max, male, age);
            
            Assert.Equal(FitnessClassification.Good, vo2MaxInterp);
        }
        
        [Fact]
        public void Interpret_Given52yrFemaleWithVo2Max45_ReturnsExcellentFitnessClassification()
        {
            var vo2MaxInterp = Vo2Max.Interpret(vo2Max, female, age);
            
            Assert.Equal(FitnessClassification.Excellent, vo2MaxInterp);
        }
    }
}