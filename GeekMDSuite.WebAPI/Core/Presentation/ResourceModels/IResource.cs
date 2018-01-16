using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;

namespace GeekMDSuite.WebAPI.Core.Presentation.ResourceModels
{
    public interface IResource<TStub>
    {
        TStub Properties { get; set; }
        List<ResourceLink> Links { get; set; }
    }
}