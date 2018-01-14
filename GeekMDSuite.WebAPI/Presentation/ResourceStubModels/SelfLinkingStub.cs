using GeekMDSuite.WebAPI.Presentation.ResourceModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class SelfLinkingStub
    {
        public SelfLinkingStub()
        {
            Link = new ResourceLink();
        }

        public ResourceLink Link { get; set; }
    }
}