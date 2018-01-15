using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.ResourceModels
{
    public class VisitResourceTests
    {
        [Fact]
        public void VisitResource_WhenInstantiated_CreatesInstanceOfPatient()
        {
            var visitResource = new VisitResource();
            Assert.NotNull(visitResource.Patient);
        }
        
        [Fact]
        public void VisitResource_WhenInstantiated_CreatesInstanceOfLinks()
        {
            var visitResource = new VisitResource();
            Assert.NotNull(visitResource.Links);
        }
        
        [Fact]
        public void VisitResource_WhenInstantiated_CreatesInstanceOfProperties()
        {
            var visitResource = new VisitResource();
            Assert.NotNull(visitResource.Properties);
        }
    }
}