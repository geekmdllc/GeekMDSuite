using System;
using Xunit;

namespace GeekMDSuite.Test
{
    public class BodyCompositionExpandedBuilderTests
    {
        [Fact]
        public void FailingToSetAllValues_ThrowsMissingMethodException()
        {
            Assert.Throws<MissingMethodException>(() => BodyCompositionExpandedBuilder.Initialize().Build());
        }
    }
}