using System;
using GeekMDSuite.WebAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {

        static FakeGeekMdSuiteContextBuilder()
        {
            XerMajestiesVisitGuid = Guid.Parse("fef15e44-74cb-4c21-aba5-d6363c45108d");
            XerMajestyGuid = Guid.Parse("3b69bd30-7a07-4859-b536-5071e0a5f516");
            BruceWaynesVisitGuid = Guid.Parse("8bfb8f23-39f4-4cde-80c6-72b178068dc4");
            BruceWayneGuid = Guid.Parse("50345ee6-fde2-4a51-8177-8c715628e39e");
        }
        public static GeekMdSuiteDbContext Context => GetContextWithData();
        
        private static GeekMdSuiteDbContext GetContextWithData()
        {
            
            
            var options = new DbContextOptionsBuilder<GeekMdSuiteDbContext>()
                .UseInMemoryDatabase("InMemory")
                .Options;
            
            var context = new GeekMdSuiteDbContext(options);

            context.Audiograms.AddRange(GetAudiogramEntities());
            context.BloodPressures.AddRange(GetBloodPressureEntities());
            context.CarotidUltrasounds.AddRange(GetCarotidUltrasoundEntities());
            context.CentralBloodPressures.AddRange(GetCentralBloodPressureEntities());
            context.FunctionalMovementScreens.AddRange(GetFunctionalMovementScreenEntities());
            context.Patients.AddRange(GetPatientEntities());
            context.Visits.AddRange(GetVisitEntities());
            
            context.SaveChanges();
 
            return context;
        }

        private static readonly Guid XerMajestiesVisitGuid;
        private static readonly Guid XerMajestyGuid;
        private static readonly Guid BruceWaynesVisitGuid;
        private static readonly Guid BruceWayneGuid;
    }
    
}