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
        public void MappingConfiguration_MapsOccularPressureEntityToOccularPressureStub_Successfully()
        {
            var entity = new OccularPressureEntity
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<OccularPressureEntity, OccularPressureStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsOccularPressureStubFromUserToOccularPressureEntity_Successfully()
        {
            var stubFromUser = new OccularPressureStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<OccularPressureStubFromUser, OccularPressureEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsOccularPressureStubFromUserToOccularPressureStub_Successfully()
        {
            var stubFromUser = new OccularPressureStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<OccularPressureStubFromUser, OccularPressureStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureStub>(stub);
        }
    }
}