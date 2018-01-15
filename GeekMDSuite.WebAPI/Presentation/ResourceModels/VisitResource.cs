using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class VisitResource : Resource<VisitStub>
    {
        public PatientStub Patient { get; set; }

        public VisitResource()
        {
            Patient = new PatientStub();
        }
    }
}