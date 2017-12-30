using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
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
            context.CentralBloodPressures.AddRange(GetCentralBloodPressureEntities());
            
            context.SaveChanges();
 
            return context;
        }
    }
}