using System;
using System.Collections.Generic;
using AutoMapper;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public class MappingConfigurationTests
    {
        private readonly IMapper _mapper;

        public MappingConfigurationTests()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = Mapper.Instance;
        }
        
        [Fact]
        public void MappingConfiguration_MapsCardiovascularRegimenEntityToCardiovascularRegimenStub_Successfully()
        {
            var cvrEntity = new CardiovascularRegimenEntity
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
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
        public void MappingConfiguration_MapsCardiovascularRegimenStubFromUserToCardiovascularRegimenEntity_Successfully()
        {
            var cvrStubFromUser = new CardiovascularRegimenStubFromUser
            {
                AverageSessionDuration = 5,
                Guid = new Guid(),
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
                Guid = new Guid(),
                Id = 0,
                Intensity = ExerciseIntensity.Moderate, 
                SessionsPerWeek = 5
            };

            var cvrEntity = _mapper.Map<CardiovascularRegimenStubFromUser, CardiovascularRegimenStub>(cvrStubFromUser);
            Mapper.Reset();
            Assert.NotNull(cvrEntity);
            Assert.IsType<CardiovascularRegimenStub>(cvrEntity);
        }
        
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
        
        [Fact]
        public void MappingConfiguration_MapsAudiogramEntityToAudiogramStub_Successfully()
        {
            var ag = new AudiogramEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var agStub = _mapper.Map<AudiogramEntity, AudiogramStub>(ag);
            Mapper.Reset();
            Assert.NotNull(agStub);
            Assert.IsType<AudiogramStub>(agStub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsAudiogramStubFromUserToAudiogramEntity_Successfully()
        {
            var agStubFromUser = new AudiogramStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var ag = _mapper.Map<AudiogramStubFromUser, Audiogram>(agStubFromUser);
            Mapper.Reset();
            Assert.NotNull(ag);
            Assert.IsType<Audiogram>(ag);
        }
        
        [Fact]
        public void MappingConfiguration_MapsAudiogramStubFromUserToAudiogramStub_Successfully()
        {
            var agStubeFromUser = new AudiogramStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var agStub = _mapper.Map<AudiogramStubFromUser, AudiogramStub>(agStubeFromUser);
            Mapper.Reset();
            Assert.NotNull(agStub);
            Assert.IsType<AudiogramStub>(agStub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionExpandedEntityToBodyCompositionExpandedStub_Successfully()
        {
            var entity = new BodyCompositionExpandedEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<BodyCompositionExpandedEntity, BodyCompositionExpandedStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionExpandedStubFromUserToBodyCompositionExpandedEntity_Successfully()
        {
            var stubFromUser = new BodyCompositionExpandedStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionExpandedStubFromUserToBodyCompositionExpandedStub_Successfully()
        {
            var stubFromUser = new BodyCompositionExpandedStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionExpandedStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionEntityToBodyCompositionStub_Successfully()
        {
            var entity = new BodyCompositionEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<BodyCompositionEntity, BodyCompositionStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionStubFromUserToBodyCompositionEntity_Successfully()
        {
            var stubFromUser = new BodyCompositionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionStubFromUser, BodyCompositionEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsBodyCompositionStubFromUserToBodyCompositionStub_Successfully()
        {
            var stubFromUser = new BodyCompositionStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<BodyCompositionStubFromUser, BodyCompositionStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<BodyCompositionStub>(stub);
        }
        
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
        
        [Fact]
        public void MappingConfiguration_MapsFunctionalMovementScreenEntityToFunctionalMovementScreenStub_Successfully()
        {
            var entity = new FunctionalMovementScreenEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<FunctionalMovementScreenEntity, FunctionalMovementScreenStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsFunctionalMovementScreenStubFromUserToFunctionalMovementScreenEntity_Successfully()
        {
            var stubFromUser = new FunctionalMovementScreenStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsFunctionalMovementScreenStubFromUserToFunctionalMovementScreenStub_Successfully()
        {
            var stubFromUser = new FunctionalMovementScreenStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<FunctionalMovementScreenStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsGripStrengthEntityToGripStrengthStub_Successfully()
        {
            var entity = new GripStrengthEntity
            {
                Guid = new Guid(),
                Id = 0,

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
                Guid = new Guid(),
                Id = 0,
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
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<GripStrengthStubFromUser, GripStrengthStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<GripStrengthStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateEntityToIshiharaSixPlateStub_Successfully()
        {
            var entity = new IshiharaSixPlateEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<IshiharaSixPlateEntity, IshiharaSixPlateStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateStubFromUserToIshiharaSixPlateEntity_Successfully()
        {
            var stubFromUser = new IshiharaSixPlateStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsIshiharaSixPlateStubFromUserToIshiharaSixPlateStub_Successfully()
        {
            var stubFromUser = new IshiharaSixPlateStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<IshiharaSixPlateStubFromUser, IshiharaSixPlateStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<IshiharaSixPlateStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsOccularPressureEntityToOccularPressureStub_Successfully()
        {
            var entity = new OccularPressureEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<OccularPressureEntity, OccularPressureStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsOccularPressureStubFromUserToOccularPressureEntity_Successfully()
        {
            var stubFromUser = new OccularPressureStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<OccularPressureStubFromUser, OccularPressureEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsOccularPressureStubFromUserToOccularPressureStub_Successfully()
        {
            var stubFromUser = new OccularPressureStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<OccularPressureStubFromUser, OccularPressureStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<OccularPressureStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsPatientEntityToPatientStub_Successfully()
        {
            var entity = new PatientEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<PatientEntity, PatientStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsPatientStubFromUserToPatientEntity_Successfully()
        {
            var stubFromUser = new PatientStubFromUser
            {
                Guid = new Guid(),
            };

            var stub = _mapper.Map<PatientStubFromUser, PatientEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsPatientStubFromUserToPatientStub_Successfully()
        {
            var stubFromUser = new PatientStubFromUser
            {
                Guid = new Guid(),
            };

            var stub = _mapper.Map<PatientStubFromUser, PatientStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientStub>(stub);
        }
        
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
        
        [Fact]
        public void MappingConfiguration_MapsPushupsEntityToPushupsStub_Successfully()
        {
            var entity = new PushupsEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<PushupsEntity, PushupsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsPushupsStubFromUserToPushupsEntity_Successfully()
        {
            var stubFromUser = new PushupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PushupsStubFromUser, PushupsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsPushupsStubFromUserToPushupsStub_Successfully()
        {
            var stubFromUser = new PushupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<PushupsStubFromUser, PushupsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PushupsStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSitAndReachEntityToSitAndReachStub_Successfully()
        {
            var entity = new SitAndReachEntity
            {
                Guid = new Guid(),
                Id = 0,

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
                Guid = new Guid(),
                Id = 0,
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
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SitAndReachStubFromUser, SitAndReachStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitAndReachStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSitupsEntityToSitupsStub_Successfully()
        {
            var entity = new SitupsEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<SitupsEntity, SitupsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSitupsStubFromUserToSitupsEntity_Successfully()
        {
            var stubFromUser = new SitupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SitupsStubFromUser, SitupsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSitupsStubFromUserToSitupsStub_Successfully()
        {
            var stubFromUser = new SitupsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SitupsStubFromUser, SitupsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SitupsStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSpirometryEntityToSpirometryStub_Successfully()
        {
            var entity = new SpirometryEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<SpirometryEntity, SpirometryStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSpirometryStubFromUserToSpirometryEntity_Successfully()
        {
            var stubFromUser = new SpirometryStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SpirometryStubFromUser, SpirometryEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsSpirometryStubFromUserToSpirometryStub_Successfully()
        {
            var stubFromUser = new SpirometryStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<SpirometryStubFromUser, SpirometryStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<SpirometryStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsTreadmillExerciseStressTestEntityToTreadmillExerciseStressTestStub_Successfully()
        {
            var entity = new TreadmillExerciseStressTestEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<TreadmillExerciseStressTestEntity, TreadmillExerciseStressTestStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsTreadmillExerciseStressTestStubFromUserToTreadmillExerciseStressTestEntity_Successfully()
        {
            var stubFromUser = new TreadmillExerciseStressTestStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsTreadmillExerciseStressTestStubFromUserToTreadmillExerciseStressTestStub_Successfully()
        {
            var stubFromUser = new TreadmillExerciseStressTestStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<TreadmillExerciseStressTestStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVisitEntityToVisitStub_Successfully()
        {
            var entity = new VisitEntity
            {
                Guid = new Guid(),
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
                Guid = new Guid(),
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
                Guid = new Guid(),
            };

            var stub = _mapper.Map<VisitStubFromUser, VisitStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisitStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVisualAcuityEntityToVisualAcuityStub_Successfully()
        {
            var entity = new VisualAcuityEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<VisualAcuityEntity, VisualAcuityStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVisualAcuityStubFromUserToVisualAcuityEntity_Successfully()
        {
            var stubFromUser = new VisualAcuityStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisualAcuityStubFromUser, VisualAcuityEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVisualAcuityStubFromUserToVisualAcuityStub_Successfully()
        {
            var stubFromUser = new VisualAcuityStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VisualAcuityStubFromUser, VisualAcuityStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VisualAcuityStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVitalSignsEntityToVitalSignsStub_Successfully()
        {
            var entity = new VitalSignsEntity
            {
                Guid = new Guid(),
                Id = 0,

            };

            var stub = _mapper.Map<VitalSignsEntity, VitalSignsStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsStub>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVitalSignsStubFromUserToVitalSignsEntity_Successfully()
        {
            var stubFromUser = new VitalSignsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VitalSignsStubFromUser, VitalSignsEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsEntity>(stub);
        }
        
        [Fact]
        public void MappingConfiguration_MapsVitalSignsStubFromUserToVitalSignsStub_Successfully()
        {
            var stubFromUser = new VitalSignsStubFromUser
            {
                Guid = new Guid(),
                Id = 0,
            };

            var stub = _mapper.Map<VitalSignsStubFromUser, VitalSignsStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<VitalSignsStub>(stub);
        }
    }
}