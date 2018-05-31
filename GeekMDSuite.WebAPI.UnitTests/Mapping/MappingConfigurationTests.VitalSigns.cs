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
        public void MappingConfiguration_MapsVitalSignsEntityToVitalSignsStub_Successfully()
        {
            var entity = new VitalSignsEntity
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<VitalSignsEntity, VitalSignsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVitalSignsStubFromUserToVitalSignsEntity_Successfully()
        {
            var stubFromUser = new VitalSignsStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<VitalSignsStubFromUser, VitalSignsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVitalSignsStubFromUserToVitalSignsStub_Successfully()
        {
            var stubFromUser = new VitalSignsStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<VitalSignsStubFromUser, VitalSignsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsStub>(stub);
        }
    }
}