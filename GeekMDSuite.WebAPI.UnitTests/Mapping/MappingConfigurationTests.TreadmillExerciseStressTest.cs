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
        public void
            MappingConfiguration_MapsTreadmillExerciseStressTestEntityToTreadmillExerciseStressTestStub_Successfully()
        {
            var entity = new TreadmillExerciseStressTestEntity
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<TreadmillExerciseStressTestEntity, TreadmillExerciseStressTestStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestStub>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsTreadmillExerciseStressTestStubFromUserToTreadmillExerciseStressTestEntity_Successfully()
        {
            var stubFromUser = new TreadmillExerciseStressTestStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub =
                _mapper.Map<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestEntity>(stub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsTreadmillExerciseStressTestStubFromUserToTreadmillExerciseStressTestStub_Successfully()
        {
            var stubFromUser = new TreadmillExerciseStressTestStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var stub =
                _mapper.Map<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestStub>(stub);
        }
    }
}