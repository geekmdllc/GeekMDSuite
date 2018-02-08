using System;
using AutoMapper;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public partial class MappingConfigurationTests
    {
        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateEntityToIshiharaSixPlateStub_Successfully()
        {
            var entity = new IshiharaSixPlateEntity
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<IshiharaSixPlateEntity, IshiharaSixPlateStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateStubFromUserToIshiharaSixPlateEntity_Successfully()
        {
            var stubFromUser = new IshiharaSixPlateStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateStubFromUserToIshiharaSixPlateStub_Successfully()
        {
            var stubFromUser = new IshiharaSixPlateStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateStub>(stub);
        }
    }
}