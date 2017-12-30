using System;
using Xunit;

namespace GeekMDSuite.UnitTests
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