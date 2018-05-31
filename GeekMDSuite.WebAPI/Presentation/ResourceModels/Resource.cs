using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class Resource<TResourceStub> : IResource<TResourceStub>
        where TResourceStub : class, new()
    {
        public Resource()
        {
            Links = new List<ResourceLink>();
            Properties = new TResourceStub();
        }

        public TResourceStub Properties { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}