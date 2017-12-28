using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class GripStrengthInterpretationTests
    {
        [Theory]
        [InlineData(GenderIdentity.Male, 60, 60, GripStrengthClassification.Weak)]
        [InlineData(GenderIdentity.Male, 100, 100, GripStrengthClassification.Normal)]
        [InlineData(GenderIdentity.Male, 150, 150, GripStrengthClassification.Strong)]
        [InlineData(GenderIdentity.Male, 60, 60, GripStrengthClassification.Weak)]
        public void Classification_GivenValues_ReturnsCorrectClassification(GenderIdentity gender, double left, double right, GripStrengthClassification expected)
        {
            _patient.Gender = Gender.Build(gender);
            var gs = GripStrength.Build(left, right);
            
            var classification = new GripStrengthInterpretation(gs, _patient).Classification;
            
            Assert.Equal(expected, classification.WorseSide);
        }
        
        [Fact]
        public void Classification_Given40yrMale150lbsL50lbsR_ReturnsWorseSideWeakLateralityRight()
        {
            var gs = GripStrength.Build(150, 50);
            
            var classification = new GripStrengthInterpretation(gs, _patient).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Right, classification.Laterality);
        }
        
        [Fact]
        public void Classification_Given40yrMale50lbsL150lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            var gs = GripStrength.Build(50, 150);
            
            var classification = new GripStrengthInterpretation(gs, _patient).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }
        
        [Fact]
        public void Classification_Given40yrFemale33lbsL66lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Female);
            var gs = GripStrength.Build(33, 66);
            
            var classification = new GripStrengthInterpretation(gs, _patient).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }

        [Fact]
        public void NullGripStrength_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new GripStrengthInterpretation(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new GripStrengthInterpretation(new Mock<IGripStrength>().Object, null));
        }

        public GripStrengthInterpretationTests()
        {
            _patient = new Patient()
            {
                DateOfBirth = DateTime.Now.AddYears(-55)
            };
        }
        private readonly Patient _patient;
    }
}