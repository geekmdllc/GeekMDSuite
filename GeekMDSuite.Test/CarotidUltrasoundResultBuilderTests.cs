using System;
using GeekMDSuite.Procedures;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CarotidUltrasoundResultBuilderTests
    {
        [Fact]
        public void FailingToSetIntimaMediaThickeness_ThrowsMissingMethodException()
        {
            Assert.Throws<MissingMethodException>(() => new CarotidUltrasoundResultBuilder().Build());
        }
    }
}