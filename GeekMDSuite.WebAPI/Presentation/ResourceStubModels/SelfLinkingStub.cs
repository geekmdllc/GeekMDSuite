using GeekMDSuite.WebAPI.Presentation.ResourceModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class SelfLinkingStub
    {
        public ResourceLink Self { get; set; }

        public SelfLinkingStub()
        {
            Self = new ResourceLink();
        }
    }
}