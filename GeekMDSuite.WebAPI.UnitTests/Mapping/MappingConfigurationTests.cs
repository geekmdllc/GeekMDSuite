using System;
using System.Collections.Generic;
using AutoMapper;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

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