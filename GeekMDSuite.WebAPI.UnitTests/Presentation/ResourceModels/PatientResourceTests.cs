using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.ResourceModels
{
    public class PatientResourceTests
    {
        [Fact]
        public void PatientResource_WhenInstantiated_CreatesInstanceOfLinks()
        {
            var patientResource = new PatientResource();

            Assert.NotNull(patientResource.Links);
        }

        [Fact]
        public void PatientResource_WhenInstantiated_CreatesInstanceOfProperties()
        {
            var patientResource = new PatientResource();

            Assert.NotNull(patientResource.Properties);
        }

        [Fact]
        public void PatientResource_WhenInstantiated_CreatesInstanceOfVisits()
        {
            var patientResource = new PatientResource();

            Assert.NotNull(patientResource.Visits);
        }
    }
}