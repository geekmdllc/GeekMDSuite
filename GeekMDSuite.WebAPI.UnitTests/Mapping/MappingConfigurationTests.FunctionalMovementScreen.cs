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
        public void MappingConfiguration_MapsFunctionalMovementScreenEntityToFunctionalMovementScreenStub_Successfully()
        {
            var entity = new FunctionalMovementScreenEntity
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<FunctionalMovementScreenEntity, FunctionalMovementScreenStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenStub>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsFunctionalMovementScreenStubFromUserToFunctionalMovementScreenEntity_Successfully()
        {
            var stubFromUser = new FunctionalMovementScreenStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenEntity>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsFunctionalMovementScreenStubFromUserToFunctionalMovementScreenStub_Successfully()
        {
            var stubFromUser = new FunctionalMovementScreenStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenStub>(stub);
        }
    }
}