using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public abstract class ResourceModel
    {    
        public List<ResourceLink> Links { get; set; }
        
        public ResourceModel()
        {
            Links = new List<ResourceLink>();
        }
    }
}