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
        public void MappingConfiguration_MapsBodyCompositionEntityToBodyCompositionStub_Successfully()
        {
            var entity = new BodyCompositionEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionEntity, BodyCompositionStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsBodyCompositionStubFromUserToBodyCompositionEntity_Successfully()
        {
            var stubFromUser = new BodyCompositionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionStubFromUser, BodyCompositionEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsBodyCompositionStubFromUserToBodyCompositionStub_Successfully()
        {
            var stubFromUser = new BodyCompositionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionStubFromUser, BodyCompositionStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionStub>(stub);
        }
    }
}