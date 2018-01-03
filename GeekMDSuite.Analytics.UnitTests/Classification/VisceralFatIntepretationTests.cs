using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
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
            var bce = BodyCompositionExpandedBuilder.Initialize()
                .SetVisceralFat(visceralFat)
                .BuildWithoutModelValidation();
            
            var classification = new VisceralFatClassification(bce).Classification;
            
            Assert.Equal(expectedVisceralFat, classification);
        }

        [Fact]
        public void NullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new VisceralFatClassification(null));
        }
    }
}