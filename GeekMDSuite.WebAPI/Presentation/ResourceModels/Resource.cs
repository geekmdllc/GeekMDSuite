using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class Resource<TResourceStub> : IResource<TResourceStub>
    {
        public TResourceStub Properties { get; set; }
        public List<ResourceLink> Links { get; set; }

        public Resource()
        {
            Links = new List<ResourceLink>();
        }
    }
}