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
        public void MappingConfiguration_MapsGripStrengthEntityToGripStrengthStub_Successfully()
        {
            var entity = new GripStrengthEntity
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<GripStrengthEntity, GripStrengthStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<GripStrengthStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsGripStrengthStubFromUserToGripStrengthEntity_Successfully()
        {
            var stubFromUser = new GripStrengthStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<GripStrengthStubFromUser, GripStrengthEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<GripStrengthEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsGripStrengthStubFromUserToGripStrengthStub_Successfully()
        {
            var stubFromUser = new GripStrengthStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<GripStrengthStubFromUser, GripStrengthStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<GripStrengthStub>(stub);
        }
    }
}