using System;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class PatientBuilderTests
    {
        [Fact]
        public void PatientBuilder_SkippingMethodInvocations_ThrowsMissingMethodException()
        {
            Assert.Throws<MissingMethodException>(() => PatientBuilder.Initialize().Build());
        }
    }
}