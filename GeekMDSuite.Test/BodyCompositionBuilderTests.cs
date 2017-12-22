using System;
using Xunit;

namespace GeekMDSuite.Test
{
    public class BodyCompositionBuilderTests
    {
        [Fact]
        public void FailingToSetAllValues_ThrowsMissingMethodException()
        {
            Assert.Throws<MissingMethodException>(() => BodyCompositionBuilder.Initialize().Build());
        }
    }
}