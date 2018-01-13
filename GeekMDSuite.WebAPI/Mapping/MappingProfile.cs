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
            CreateMap<VisitStub, VisitEntity>();
            CreateMap<PatientEntity, PatientStub>();
            CreateMap<PatientStub, PatientEntity>();
        }
    }
}