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
        public void MappingConfiguration_MapsBodyCompositionExpandedEntityToBodyCompositionExpandedStub_Successfully()
        {
            var entity = new BodyCompositionExpandedEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionExpandedEntity, BodyCompositionExpandedStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedStub>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsBodyCompositionExpandedStubFromUserToBodyCompositionExpandedEntity_Successfully()
        {
            var stubFromUser = new BodyCompositionExpandedStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedEntity>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsBodyCompositionExpandedStubFromUserToBodyCompositionExpandedStub_Successfully()
        {
            var stubFromUser = new BodyCompositionExpandedStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedStub>(stub);
        }
    }
}