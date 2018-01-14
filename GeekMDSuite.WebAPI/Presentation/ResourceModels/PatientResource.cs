using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class PatientResource : ResourceModel
    {
        public PatientStub Patient { get; set; }
        public List<VisitStub> Visits { get; set; }
    }
}