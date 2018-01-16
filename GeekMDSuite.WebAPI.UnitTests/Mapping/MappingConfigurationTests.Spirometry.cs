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
        public void MappingConfiguration_MapsSpirometryEntityToSpirometryStub_Successfully()
        {
            var entity = new SpirometryEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SpirometryEntity, SpirometryStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSpirometryStubFromUserToSpirometryEntity_Successfully()
        {
            var stubFromUser = new SpirometryStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SpirometryStubFromUser, SpirometryEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSpirometryStubFromUserToSpirometryStub_Successfully()
        {
            var stubFromUser = new SpirometryStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SpirometryStubFromUser, SpirometryStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryStub>(stub);
        }
    }
}