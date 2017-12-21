using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class VisceralFatIntepretationTests
    {
        [Fact]
        public void Classfication_GivenVisceralFatLessThan50_ReturnsExcellent()
        {
            var mockBodyCompExpanded = new Mock<IBodyCompositionExpanded>();
            mockBodyCompExpanded.Setup(bc => bc.VisceralFat).Returns(45);
            
            var classification = new VisceralFatInterpretation(mockBodyCompExpanded.Object).Classification;
            
            Assert.Equal(VisceralFat.Excellent, classification);
        }
        
        [Fact]
        public void Classfication_GivenVisceralFatLessThan100_ReturnsAcceptable()
        {
            var mockBodyCompExpanded = new Mock<IBodyCompositionExpanded>();
            mockBodyCompExpanded.Setup(bc => bc.VisceralFat).Returns(99);
            
            var classification = new VisceralFatInterpretation(mockBodyCompExpanded.Object).Classification;
            
            Assert.Equal(VisceralFat.Acceptable, classification);
        }
        
        [Fact]
        public void Classfication_GivenVisceralFatLessThan150_ReturnsElevated()
        {
            var mockBodyCompExpanded = new Mock<IBodyCompositionExpanded>();
            mockBodyCompExpanded.Setup(bc => bc.VisceralFat).Returns(149);
            
            var classification = new VisceralFatInterpretation(mockBodyCompExpanded.Object).Classification;
            
            Assert.Equal(VisceralFat.Elevated, classification);
        }
        
        [Fact]
        public void Classfication_GivenVisceralFatGreaterOrEqualTo150_ReturnsExcellent()
        {
            var mockBodyCompExpanded = new Mock<IBodyCompositionExpanded>();
            mockBodyCompExpanded.Setup(bc => bc.VisceralFat).Returns(150);
            
            var classification = new VisceralFatInterpretation(mockBodyCompExpanded.Object).Classification;
            
            Assert.Equal(VisceralFat.VeryElevated, classification);
        }
    }
}