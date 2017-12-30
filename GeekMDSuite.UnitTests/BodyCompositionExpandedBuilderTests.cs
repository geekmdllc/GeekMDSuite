using System;
using Xunit;

namespace GeekMDSuite.UnitTests
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