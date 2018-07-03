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
        public void MappingConfiguration_MapsCardiovascularRegimenEntityToCardiovascularRegimenStub_Successfully()
        {
            var cvrEntity = new CardiovascularRegimenEntity
            {
                AverageSessionDuration = 5,
                VisitGuid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrStub = _mapper.Map<CardiovascularRegimenEntity, CardiovascularRegimenStub>(cvrEntity);
            Mapper.Reset();
            Assert.NotNull(cvrStub);
            Assert.IsType<CardiovascularRegimenStub>(cvrStub);
        }

        [Fact]
        public void
            MappingConfiguration_MapsCardiovascularRegimenStubFromUserToCardiovascularRegimenEntity_Successfully()
        {
            var cvrStubFromUser = new CardiovascularRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                VisitGuid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrEntity = _mapper.Map<CardiovascularRegimenStubFromUser, CardiovascularRegimen>(cvrStubFromUser);
            Mapper.Reset();
            Assert.NotNull(cvrEntity);
            Assert.IsType<CardiovascularRegimen>(cvrEntity);
        }

        [Fact]
        public void MappingConfiguration_MapsCardiovascularRegimenStubFromUserToCardiovascularRegimenStub_Successfully()
        {
            var cvrStubFromUser = new CardiovascularRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                VisitGuid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate,
                SessionsPerWeek = 5
            };

            var cvrEntity = _mapper.Map<CardiovascularRegimenStubFromUser, CardiovascularRegimenStub>(cvrStubFromUser);
            Mapper.Reset();
            Assert.NotNull(cvrEntity);
            Assert.IsType<CardiovascularRegimenStub>(cvrEntity);
        }
    }
}