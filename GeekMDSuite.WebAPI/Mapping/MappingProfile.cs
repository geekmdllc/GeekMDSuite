using AutoMapper;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VisitEntity, VisitStub>();
            CreateMap<VisitStubFromUser, VisitEntity>();
            CreateMap<VisitStubFromUser, VisitStub>();
            CreateMap<PatientEntity, PatientStub>();
            CreateMap<PatientStubFromUser, PatientEntity>();
            CreateMap<PatientStubFromUser, PatientStub>();
        }
    }
}