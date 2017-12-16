using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class GripStrengthInterpretationTests
    {
        [Fact]
        public void Classification_Given40yrMale60lbsL60lbsR_ReturnsWeak()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var gs = new GripStrength(new GripMeasurement(60), new GripMeasurement(60));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
        }
        
        [Fact]
        public void Classification_Given40yrMale100lbsL100lbsR_ReturnsNormal()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var gs = new GripStrength(new GripMeasurement(100), new GripMeasurement(100));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Normal, classification.WorseSide);
        }
        
        [Fact]
        public void Classification_Given40yrMale150lbsL150lbsR_ReturnsStrong()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var gs = new GripStrength(new GripMeasurement(150), new GripMeasurement(150));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Strong, classification.WorseSide);
        }
        
        [Fact]
        public void Classification_Given40yrMale150lbsL50lbsR_ReturnsWorseSideWeakLateralityRight()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var gs = new GripStrength(new GripMeasurement(150), new GripMeasurement(50));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Right, classification.Laterality);
        }
        
        [Fact]
        public void Classification_Given40yrMale50lbsL150lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXy);
            var gs = new GripStrength(new GripMeasurement(50), new GripMeasurement(150));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }
        
        [Fact]
        public void Classification_Given40yrFemale33lbsL66lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            var mockPt = new Mock<IPatient>();
            mockPt.Setup(p => p.Age).Returns(40);
            mockPt.Setup(p => p.Gender.Category).Returns(GenderIdentity.NonBinaryXx);
            var gs = new GripStrength(new GripMeasurement(33), new GripMeasurement(66));
            
            var classification = new GripStrengthInterpretation(gs, mockPt.Object).Classification;
            
            Assert.Equal(GripStrengthClassification.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }
    }
}