using System;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Moq;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class VisceralFatInterpretationTests
    {
        [Theory]
        [InlineData(45, VisceralFat.Excellent)]
        [InlineData(99, VisceralFat.Acceptable)]
        [InlineData(149, VisceralFat.Elevated)]
        [InlineData(150, VisceralFat.VeryElevated)]
        public void Classification_GivenData_ReturnsCorrectClassification(double visceralFat, VisceralFat expectedVisceralFat)
        {
            var mockBodyCompExpanded = new Mock<IBodyCompositionExpanded>();
            mockBodyCompExpanded.Setup(bc => bc.VisceralFat).Returns(visceralFat);
            
            var classification = new VisceralFatClassification(mockBodyCompExpanded.Object).Classification;
            
            Assert.Equal(expectedVisceralFat, classification);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new VisceralFatClassification(null));
        }
    }
}