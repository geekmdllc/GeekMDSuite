using System;
using GeekMDSuite.Contracts;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class Vo2MaxTest
    {
        private double vo2Max = 45;
        private Gender male = Gender.NonBinaryXy;
        private Gender female = Gender.Female;
        private double age = 52;

        [Fact]
        public void ReturnsCorrectInterpetationForMale()
        {
            var vo2MaxInterp = Vo2Max.Interpret(vo2Max, male, age);
            
            Assert.Equal(FitnessClassification.Good, vo2MaxInterp);
        }
        
        [Fact]
        public void ReturnsCorrectInterpetationForFemale()
        {
            var vo2MaxInterp = Vo2Max.Interpret(vo2Max, female, age);
            
            Assert.Equal(FitnessClassification.Excellent, vo2MaxInterp);
        }
    }
}