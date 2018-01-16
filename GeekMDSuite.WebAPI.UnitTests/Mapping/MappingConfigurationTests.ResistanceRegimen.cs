using System;
using System.Collections.Generic;
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
        public void MappingConfiguration_MapsResistanceRegimenEntityToResistanceRegimenStub_Successfully()
        {
            var cvrEntity = new ResistanceRegimenEntity
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrStub = _mapper.Map<ResistanceRegimenEntity, ResistanceRegimenStub>(cvrEntity);
            Mapper.Reset();
            Assert.NotNull(cvrStub);
            Assert.IsType<ResistanceRegimenStub>(cvrStub);
        }

        [Fact]
        public void MappingConfiguration_MapsResistanceRegimenStubFromUserToResistanceRegimenEntity_Successfully()
        {
            var cvrStubFromUser = new ResistanceRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrEntity = _mapper.Map<ResistanceRegimenStubFromUser, ResistanceRegimen>(cvrStubFromUser);
            Mapper.Reset();
            Assert.NotNull(cvrEntity);
            Assert.IsType<ResistanceRegimen>(cvrEntity);
        }

        [Fact]
        public void MappingConfiguration_MapsResistanceRegimenStubFromUserToResistanceRegimenStub_Successfully()
        {
            var resiStubFromUser = new ResistanceRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5,
                Features = new List<ResistenceRegimenFeatures>()
            };

            var resStub = _mapper.Map<ResistanceRegimenStubFromUser, ResistanceRegimenStub>(resiStubFromUser);
            Mapper.Reset();
            Assert.NotNull(resStub);
            Assert.IsType<ResistanceRegimenStub>(resStub);
        }
    }
}