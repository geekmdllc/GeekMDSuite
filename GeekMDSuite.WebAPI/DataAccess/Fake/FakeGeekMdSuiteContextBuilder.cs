using System;
using System.Collections.Generic;
using System.Net.Sockets;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static GeekMdSuiteDbContext Context => GetContextWithData();
        public static GeekMdSuiteDbContext EmptyContext => GetContextWithoutData();

        private static GeekMdSuiteDbContext GetContextWithoutData()
        {
            var options = new DbContextOptionsBuilder<GeekMdSuiteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GeekMdSuiteDbContext(options);
        }

        private static GeekMdSuiteDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<GeekMdSuiteDbContext>()
                .UseInMemoryDatabase("InMemory")
                .Options;
            
            var context = new GeekMdSuiteDbContext(options);

            context.Audiograms.AddRange(GetAudiogramEntities());
            context.BloodPressures.AddRange(GetBloodPressureEntities());
            context.BodyCompositions.AddRange(GetBodyCompositionEntities());
            context.BodyCompositionExpandeds.AddRange(GetBodyCompositionExpandedEntities());
            context.CarotidUltrasounds.AddRange(GetCarotidUltrasoundEntities());
            context.CentralBloodPressures.AddRange(GetCentralBloodPressureEntities());
            context.FunctionalMovementScreens.AddRange(GetFunctionalMovementScreenEntities());
            context.GripStrengths.AddRange(GetGripStrengthEntities());
            context.OcularPressures.AddRange(GetOcularPressureEntities());
            context.Patients.AddRange(GetPatientEntities());
            context.PeripheralVisions.AddRange(GetPeripheralVisionEntities());
            context.Pushups.AddRange(GetPushupsEntities());
            context.SitAndReaches.AddRange(GetSitAndReachEntities());
            context.Situps.AddRange(GetSitupEntities());
            context.Spirometries.AddRange(GetSpirometryEntities());
            context.TreadmillExerciseStressTests.AddRange(GetTreadmillExerciseStressTestEntities());
            context.Visits.AddRange(GetVisitEntities());
            context.VisualAcuities.AddRange(GetVisualAcuityEntities());
            context.VitalSigns.AddRange(GetVitalSignsEntities());
            context.SaveChanges();
 
            return context;
        }

        private static readonly Guid XerMajestiesVisitGuid = Guid.Parse("fef15e44-74cb-4c21-aba5-d6363c45108d");
        private static readonly Guid XerMajestyGuid = Guid.Parse("3b69bd30-7a07-4859-b536-5071e0a5f516");
        private static readonly Guid BruceWaynesVisitGuid = Guid.Parse("8bfb8f23-39f4-4cde-80c6-72b178068dc4");
        private static readonly Guid BruceWayneGuid = Guid.Parse("50345ee6-fde2-4a51-8177-8c715628e39e");
    }
    
}