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
        public void MappingConfiguration_MapsVisitEntityToVisitStub_Successfully()
        {
            var entity = new VisitEntity
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisitEntity, VisitStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisitStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVisitStubFromUserToVisitEntity_Successfully()
        {
            var stubFromUser = new VisitStubFromUser
            {
                VisitGuid = new Guid(),
            };

            var stub = _mapper.Map<VisitStubFromUser, VisitEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisitEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsVisitStubFromUserToVisitStub_Successfully()
        {
            var stubFromUser = new VisitStubFromUser
            {
                VisitGuid = new Guid(),
            };

            var stub = _mapper.Map<VisitStubFromUser, VisitStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisitStub>(stub);
        }
    }
}