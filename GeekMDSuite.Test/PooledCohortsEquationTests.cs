using System;
using System.ComponentModel;
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

        [Fact]
        public void WrongQuantitativeLabType_InPlaceOfCholesterolTotal_ThrowsException()
        {
            Assert.Throws<InvalidEnumArgumentException>(() =>
                new PooledCohortsEquation(new Mock<IPatient>().Object, new Mock<IBloodPressure>().Object, TestosteroneTotal(213), HighDensityLipoprotein(50)));
        }
        
        [Fact]
        public void WrongQuantitativeLabType_InPlaceOfHighDensityLipoprotein_ThrowsException()
        {
            Assert.Throws<InvalidEnumArgumentException>(() =>
                new PooledCohortsEquation(new Mock<IPatient>().Object, new Mock<IBloodPressure>().Object, CholesterolTotal(213), TestosteroneTotal(50)));
        }
    }
}