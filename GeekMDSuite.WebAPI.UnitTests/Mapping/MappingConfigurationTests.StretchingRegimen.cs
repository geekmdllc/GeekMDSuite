using System;
using AutoMapper;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public partial class MappingConfigurationTests
    {
        [Fact]
        public void MappingConfiguration_MapsStretchingRegimenEntityToStretchingRegimenStub_Successfully()
        {
            var cvrEntity = new StretchingRegimenEntity
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrStub = _mapper.Map<StretchingRegimenEntity, StretchingRegimenStub>(cvrEntity);
            Mapper.Reset();
            Assert.NotNull(cvrStub);
            Assert.IsType<StretchingRegimenStub>(cvrStub);
        }

        [Fact]
        public void MappingConfiguration_MapsStretchingRegimenStubFromUserToStretchingRegimenEntity_Successfully()
        {
            var stub = new StretchingRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var entity = _mapper.Map<StretchingRegimenStubFromUser, StretchingRegimenEntity>(stub);
            Mapper.Reset();
            Assert.NotNull(entity);
            Assert.IsType<StretchingRegimenEntity>(entity);
        }

        [Fact]
        public void MappingConfiguration_MapsStretchingRegimenStubFromUserToStretchingRegimenStub_Successfully()
        {
            var stubFromUser = new StretchingRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var entity = _mapper.Map<StretchingRegimenStubFromUser, StretchingRegimenStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(entity);
            Assert.IsType<StretchingRegimenStub>(entity);
        }
    }
}