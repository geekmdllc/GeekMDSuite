using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class VisitResource : Resource<VisitStub>
    {
        public VisitResource()
        {
            Patient = new PatientStub();
        }

        public PatientStub Patient { get; set; }
    }
}