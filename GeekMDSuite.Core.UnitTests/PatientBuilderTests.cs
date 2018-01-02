using System;
using GeekMDSuite.Core;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
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