using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class HipToWaistInterpretationTests
    {
        [Fact]
        public void Classification_GivenMaleLessThanZeroPoint9_ReturnsHealthy()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(10);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(8.9);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Normal, classification);
        }
        
        [Fact]
        public void Classification_GivenMaleLessThanOne_ReturnsOverweight()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(10);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(9.9);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Overweight, classification);
        }
        
        [Fact]
        public void Classification_GivenMaleEqualToOne_ReturnsObese()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(1);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(1);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Obese, classification);
        }
        
        [Fact]
        public void Classification_GivenFemaleLessThanZeroPoint8_ReturnsHealthy()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(10);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(7.9);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Normal, classification);
        }
        
        [Fact]
        public void Classification_GivenFemaleLessZeroPoint85_ReturnsOverweight()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(10);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(8.4);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Overweight, classification);
        }
        
        [Fact]
        public void Classification_GivenFemaleEqualToZeroPoint85_ReturnsObese()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);
            var mockBodyComposition = new Mock<IBodyComposition>();
            mockBodyComposition.Setup(b => b.Hips.Inches).Returns(1);
            mockBodyComposition.Setup(b => b.Waist.Inches).Returns(8.5);

            var classification = new HipToWaistInterpretation(mockBodyComposition.Object, mockPatient.Object).Classification;
            Assert.Equal(HipToWaistRatioClassification.Obese, classification);
        }
    }
    
    
}