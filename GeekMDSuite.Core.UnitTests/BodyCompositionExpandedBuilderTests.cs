using System;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
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