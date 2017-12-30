using GeekMDSuite.WebAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
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
    }
    
}