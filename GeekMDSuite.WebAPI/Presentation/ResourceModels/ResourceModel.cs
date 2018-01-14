using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public abstract class ResourceModel
    {    
        public List<ResourceLink> Links { get; set; }
    }
}