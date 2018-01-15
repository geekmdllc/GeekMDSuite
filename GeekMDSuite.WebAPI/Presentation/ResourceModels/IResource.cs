using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public interface IResource<TStub>
    {
        TStub Properties { get; set; }
        List<ResourceLink> Links { get; set; }
    }
}