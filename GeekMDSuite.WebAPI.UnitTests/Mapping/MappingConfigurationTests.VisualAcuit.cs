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
        public void MappingConfiguration_MapsVisualAcuityEntityToVisualAcuityStub_Successfully()
        {
            var entity = new VisualAcuityEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisualAcuityEntity, VisualAcuityStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVisualAcuityStubFromUserToVisualAcuityEntity_Successfully()
        {
            var stubFromUser = new VisualAcuityStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisualAcuityStubFromUser, VisualAcuityEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVisualAcuityStubFromUserToVisualAcuityStub_Successfully()
        {
            var stubFromUser = new VisualAcuityStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisualAcuityStubFromUser, VisualAcuityStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityStub>(stub);
        }
    }
}