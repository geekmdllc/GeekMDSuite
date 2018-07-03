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
        public void MappingConfiguration_MapsSitupsEntityToSitupsStub_Successfully()
        {
            var entity = new SitupsEntity
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitupsEntity, SitupsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSitupsStubFromUserToSitupsEntity_Successfully()
        {
            var stubFromUser = new SitupsStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitupsStubFromUser, SitupsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSitupsStubFromUserToSitupsStub_Successfully()
        {
            var stubFromUser = new SitupsStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitupsStubFromUser, SitupsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsStub>(stub);
        }
    }
}