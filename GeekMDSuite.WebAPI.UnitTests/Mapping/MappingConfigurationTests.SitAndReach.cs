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
        public void MappingConfiguration_MapsSitAndReachEntityToSitAndReachStub_Successfully()
        {
            var entity = new SitAndReachEntity
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitAndReachEntity, SitAndReachStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitAndReachStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSitAndReachStubFromUserToSitAndReachEntity_Successfully()
        {
            var stubFromUser = new SitAndReachStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitAndReachStubFromUser, SitAndReachEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitAndReachEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsSitAndReachStubFromUserToSitAndReachStub_Successfully()
        {
            var stubFromUser = new SitAndReachStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<SitAndReachStubFromUser, SitAndReachStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitAndReachStub>(stub);
        }
    }
}