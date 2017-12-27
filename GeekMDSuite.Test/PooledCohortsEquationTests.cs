using System;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;
using static GeekMDSuite.LaboratoryData.Builder.Quantitative.Serum;

namespace GeekMDSuite.Test
{
    public partial class PooledCohortsEquationTests
    {
        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PooledCohortsEquation(null, new Mock<IBloodPressure>().Object, CholesterolTotal(213), HighDensityLipoprotein(50)));
        }
        
        [Fact]
        public void NullBloodPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PooledCohortsEquation(new Mock<IPatient>().Object, null, CholesterolTotal(213), HighDensityLipoprotein(50)));
        }
    }
}