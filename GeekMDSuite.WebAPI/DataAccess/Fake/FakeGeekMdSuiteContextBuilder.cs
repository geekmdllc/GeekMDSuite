using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Persistence;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static class FakeGeekMdSuiteContextBuilder
        {
            public static GeekMdSuiteDbContext Context => GetContextWithData();
            
            private static GeekMdSuiteDbContext GetContextWithData()
            {
                var options = new DbContextOptionsBuilder<GeekMdSuiteDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                
                var context = new GeekMdSuiteDbContext(options);
    
                context.Audiograms.AddRange(GetAudiogramEntities());
                context.Patients.AddRange(GetPatientEntities());
                context.CarotidUltrasounds.AddRange(GetCarotidUltrasoundEntities());
                
                context.SaveChanges();
     
                return context;
            }

            private static List<CarotidUltrasoundEntity> GetCarotidUltrasoundEntities()
            {
                var left = CarotidUltrasoundResultBuilder.Initialize()
                    .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                    .SetIntimaMediaThickeness(0.655)
                    .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                    .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                    .Build();
                var right  = CarotidUltrasoundResultBuilder.Initialize()
                    .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                    .SetIntimaMediaThickeness(0.655)
                    .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                    .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                    .Build();
                var cu = CarotidUltrasound.Build(left, right);
                var cue = new CarotidUltrasoundEntity(cu);

                return new List<CarotidUltrasoundEntity>()
                {
                    cue,
                    cue,
                    cue
                };
            }
            
            private static List<PatientEntity> GetPatientEntities()
            {
                var p1 = PatientBuilder.Initialize()
                    .SetDateOfBirth(1900, 1, 1)
                    .SetGender(GenderIdentity.Male)
                    .SetMedicalRecordNumber("12345")
                    .SetName("Bruce", "Wayne")
                    .SetRace(Race.White)
                    .Build();
                
                var p2 = PatientBuilder.Initialize()
                    .SetDateOfBirth(1990, 2, 2)
                    .SetGender(GenderIdentity.NonBinaryXx)
                    .SetMedicalRecordNumber("54321")
                    .SetName("Xer", "Majesty")
                    .SetRace(Race.Unknown)
                    .Build();
                
                return new List<PatientEntity>()
                {
                    new PatientEntity(p1),
                    new PatientEntity(p2)
                };
            }
            
            private static List<AudiogramEntity> GetAudiogramEntities()
            {
                var left = AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(10)
                    .Set250HertzDataPoint(10)
                    .Set500HertzDataPoint(90)
                    .Set1000HertzDataPoint(25)
                    .Set2000HertzDataPoint(30)
                    .Set3000HertzDataPoint(25)
                    .Set4000HertzDataPoint(40)
                    .Set6000HertzDataPoint(60)
                    .Set8000HertzDataPoint(65)
                    .Build();
                var right = AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(15)
                    .Set250HertzDataPoint(15)
                    .Set500HertzDataPoint(25)
                    .Set1000HertzDataPoint(20)
                    .Set2000HertzDataPoint(35)
                    .Set3000HertzDataPoint(20)
                    .Set4000HertzDataPoint(45)
                    .Set6000HertzDataPoint(65)
                    .Set8000HertzDataPoint(60)
                    .Build();
                var audiogram = Audiogram.Build(left, right);
                
                var left2 = AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(10)
                    .Set250HertzDataPoint(10)
                    .Set500HertzDataPoint(10)
                    .Set1000HertzDataPoint(10)
                    .Set2000HertzDataPoint(10)
                    .Set3000HertzDataPoint(10)
                    .Set4000HertzDataPoint(10)
                    .Set6000HertzDataPoint(10)
                    .Set8000HertzDataPoint(10)
                    .Build();
                var right2 = AudiogramDatasetBuilder.Initialize()
                    .Set125HertzDataPoint(10)
                    .Set250HertzDataPoint(10)
                    .Set500HertzDataPoint(10)
                    .Set1000HertzDataPoint(10)
                    .Set2000HertzDataPoint(10)
                    .Set3000HertzDataPoint(10)
                    .Set4000HertzDataPoint(10)
                    .Set6000HertzDataPoint(10)
                    .Set8000HertzDataPoint(10)
                    .Build();
    
                var audiogram2 = Audiogram.Build(left2, right2);
                
                return new List<AudiogramEntity>()
                {
                    new AudiogramEntity(audiogram),
                    new AudiogramEntity(audiogram2)
                };
            }
        }
}