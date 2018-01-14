using GeekMDSuite.WebAPI.Presentation.ResourceModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class SelfLinkingStub
    {
        public ResourceLink Link { get; set; }

        public SelfLinkingStub()
        {
            Link = new ResourceLink();
        }
    }
}