using AutoMapper;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cardiovascular Regimen
            CreateMap<CardiovascularRegimenEntity, CardiovascularRegimenStub>();
            CreateMap<CardiovascularRegimenStubFromUser, CardiovascularRegimenEntity>();
            CreateMap<CardiovascularRegimenStubFromUser, CardiovascularRegimenStub>();
            // ResistanceRegimen
            CreateMap<ResistanceRegimenEntity, ResistanceRegimenStub>();
            CreateMap<ResistanceRegimenStubFromUser, ResistanceRegimenEntity>();
            CreateMap<ResistanceRegimenStubFromUser, ResistanceRegimenStub>();
            // Stretching Regimen
            CreateMap<StretchingRegimenEntity, StretchingRegimenStub>();
            CreateMap<StretchingRegimenStubFromUser, GripStrengthEntity>();
            CreateMap<StretchingRegimenStubFromUser, StretchingRegimenStub>();
            // Audiogram
            CreateMap<AudiogramEntity, AudiogramStub>();
            CreateMap<AudiogramStubFromUser, AudiogramEntity>();
            CreateMap<AudiogramStubFromUser, AudiogramStub>();
            // Blood Pressure
            CreateMap<BloodPressureEntity, BloodPressureStub>();
            CreateMap<BloodPressureStubFromUser, BloodPressureEntity>();
            CreateMap<BloodPressureStubFromUser, BloodPressureStub>();
            // Body Composition
            CreateMap<BodyCompositionEntity, BodyCompositionStub>();
            CreateMap<BodyCompositionStubFromUser, BodyCompositionEntity>();
            CreateMap<BodyCompositionStubFromUser, BodyCompositionStub>();
            // Body Composition Expanded
            CreateMap<BodyCompositionExpandedEntity, BodyCompositionExpandedStub>();
            CreateMap<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedEntity>();
            CreateMap<BodyCompositionExpandedStubFromUser, BodyCompositionExpandedStub>();
            // Carotid Ultrasound
            CreateMap<CarotidUltrasoundEntity, CarotidUltrasoundStub>();
            CreateMap<CarotidUltrasoundStubFromUser, CarotidUltrasoundEntity>();
            CreateMap<CarotidUltrasoundStubFromUser, CarotidUltrasoundStub>();
            // Central Blood Pressure
            CreateMap<CentralBloodPressureEntity, CentralBloodPressureStub>();
            CreateMap<CentralBloodPressureStubFromUser, CentralBloodPressureEntity>();
            CreateMap<CentralBloodPressureStubFromUser, CentralBloodPressureStub>();
            // Functional Movement Screen
            CreateMap<FunctionalMovementScreenEntity, FunctionalMovementScreenStub>();
            CreateMap<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenEntity>();
            CreateMap<FunctionalMovementScreenStubFromUser, FunctionalMovementScreenStub>();
            // Grip Strength
            CreateMap<GripStrengthEntity, GripStrengthStub>();
            CreateMap<GripStrengthStubFromUser, GripStrengthEntity>();
            CreateMap<GripStrengthStubFromUser, GripStrengthStub>();
            // Ishihara Six Plate
            CreateMap<IshiharaSixPlateEntity, IshiharaSixPlateStub>();
            CreateMap<IshiharaSixPlateStubFromUser, IshiharaSixPlateEntity>();
            CreateMap<IshiharaSixPlateStubFromUser, IshiharaSixPlateStub>();
            // Occular Pressure
            CreateMap<OccularPressureEntity, OccularPressureStub>();
            CreateMap<OccularPressureStubFromUser, OccularPressureEntity>();
            CreateMap<OccularPressureStubFromUser, OccularPressureStub>();
            // Patient
            CreateMap<PatientEntity, PatientStub>();
            CreateMap<PatientStubFromUser, PatientEntity>();
            CreateMap<PatientStubFromUser, PatientStub>();
            // Peripheral Vision
            CreateMap<PeripheralVisionEntity, PeripheralVistionStub>();
            CreateMap<PeripheralVisionStubFromUser, PeripheralVisionEntity>();
            CreateMap<PeripheralVisionStubFromUser, PeripheralVisionEntity>();
            // Pushups 
            CreateMap<PushupsEntity, PushupsStub>();
            CreateMap<PushupsStubFromUser, PushupsEntity>();
            CreateMap<PushupsStubFromUser, PushupsStub>();
            // Sit and Reach
            CreateMap<SitAndReachEntity, SitAndReachStub>();
            CreateMap<SitAndReachStubFromUser, SitAndReachEntity>();
            CreateMap<SitAndReachStub, SitAndReachStub>();
            // Situps
            CreateMap<SitupsEntity, SitupsStub>();
            CreateMap<SitupsStubFromUser, SitupsEntity>();
            CreateMap<SitupsStubFromUser, SitupsStub>();
            // Spirometry
            CreateMap<SpirometryEntity, SpirometryStub>();
            CreateMap<SpirometryStubFromUser, SpirometryEntity>();
            CreateMap<SpirometryStubFromUser, SpirometryStub>();
            // Treadmill Exercise Stress TEst
            CreateMap<TreadmillExerciseStressTestEntity, TreadmillExerciseStressTestStub>();
            CreateMap<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestEntity>();
            CreateMap<TreadmillExerciseStressTestStubFromUser, TreadmillExerciseStressTestStub>();
            // Visit
            CreateMap<VisitEntity, VisitStub>();
            CreateMap<VisitStubFromUser, VisitEntity>();
            CreateMap<VisitStubFromUser, VisitStub>();
            // Visual Acuity
            CreateMap<VisualAcuityEntity, VisualAcuityStub>();
            CreateMap<VisualAcuityStubFromUser, VisualAcuityEntity>();
            CreateMap<VisualAcuityStubFromUser, VisualAcuityStub>();
            // Vital Signs
            CreateMap<VitalSignsEntity, VitalSignsStub>();
            CreateMap<VitalSignsStubFromUser, VitalSignsEntity>();
            CreateMap<VitalSignsStubFromUser, VitalSignsStub>();
        }
    }
}