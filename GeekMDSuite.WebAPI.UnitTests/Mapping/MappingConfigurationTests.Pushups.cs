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
        public void MappingConfiguration_MapsPushupsEntityToPushupsStub_Successfully()
        {
            var entity = new PushupsEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PushupsEntity, PushupsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPushupsStubFromUserToPushupsEntity_Successfully()
        {
            var stubFromUser = new PushupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PushupsStubFromUser, PushupsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPushupsStubFromUserToPushupsStub_Successfully()
        {
            var stubFromUser = new PushupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PushupsStubFromUser, PushupsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsStub>(stub);
        }
    }
}