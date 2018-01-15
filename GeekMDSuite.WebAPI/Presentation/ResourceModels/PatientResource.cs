using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class PatientResource : Resource<PatientStub>
    {
        public List<VisitStub> Visits { get; set; }

        public PatientResource()
        {
            Visits = new List<VisitStub>();
        }
    }
}