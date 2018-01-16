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
        public void MappingConfiguration_MapsCarotidUltrasoundEntityToCarotidUltrasoundStub_Successfully()
        {
            var entity = new CarotidUltrasoundEntity
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<CarotidUltrasoundEntity, CarotidUltrasoundStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<CarotidUltrasoundStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsCarotidUltrasoundStubFromUserToCarotidUltrasoundEntity_Successfully()
        {
            var stubFromUser = new CarotidUltrasoundStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<CarotidUltrasoundStubFromUser, CarotidUltrasoundEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<CarotidUltrasoundEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsCarotidUltrasoundStubFromUserToCarotidUltrasoundStub_Successfully()
        {
            var stubFromUser = new CarotidUltrasoundStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<CarotidUltrasoundStubFromUser, CarotidUltrasoundStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<CarotidUltrasoundStub>(stub);
        }
    }
}