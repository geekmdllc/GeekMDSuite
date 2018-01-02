using System;
using GeekMDSuite.Core;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
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