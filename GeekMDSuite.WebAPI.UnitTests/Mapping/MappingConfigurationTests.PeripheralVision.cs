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
        public void MappingConfiguration_MapsPeripheralVisionEntityToPeripheralVisionStub_Successfully()
        {
            var entity = new PeripheralVisionEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PeripheralVisionEntity, PeripheralVisionStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PeripheralVisionStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPeripheralVisionStubFromUserToPeripheralVisionEntity_Successfully()
        {
            var stubFromUser = new PeripheralVisionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PeripheralVisionStubFromUser, PeripheralVisionEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PeripheralVisionEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPeripheralVisionStubFromUserToPeripheralVisionStub_Successfully()
        {
            var stubFromUser = new PeripheralVisionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PeripheralVisionStubFromUser, PeripheralVisionStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PeripheralVisionStub>(stub);
        }
    }
}