using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public abstract class ResourceModel
    {
        public ResourceModel()
        {
            Links = new List<ResourceLink>();
        }

        public List<ResourceLink> Links { get; set; }
    }
}