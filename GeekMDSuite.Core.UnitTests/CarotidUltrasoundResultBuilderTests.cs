using System;
using GeekMDSuite.Core.Procedures;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
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