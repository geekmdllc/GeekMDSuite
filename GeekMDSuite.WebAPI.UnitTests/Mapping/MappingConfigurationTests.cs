using AutoMapper;
using GeekMDSuite.WebAPI.Mapping;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public partial class MappingConfigurationTests
    {
        private readonly IMapper _mapper;

        public MappingConfigurationTests()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = Mapper.Instance;
        }
    }
}