using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class VisitResource : ResourceModel
    {
        public VisitStub Visit { get; set; }
        public PatientStub Patient { get; set; }
    }
}