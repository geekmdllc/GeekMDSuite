using System;
using AspNet.Mvc.TypedRouting.Routing;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using With = Microsoft.AspNetCore.Builder.With;

namespace GeekMDSuite.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var baseUrl = Configuration.GetSection("ApiBaseUrl").Value;

            services.AddMvc()
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters()
                .AddTypedRouting(RoutesConfiguration(baseUrl));
            services.AddDbContext<GeekMdSuiteDbContext>(options => options.UseSqlite(connection));
            services.AddSingleton<INewPatientService, NewPatientService>();
            services.AddSingleton<INewVisitService, NewVisitService>();
            services.AddSingleton<IClassificationRepository, ClassificationRepository>();
            if (Environment.IsDevelopment())
                services.AddSingleton<IUnitOfWork, FakeUnitOfWorkSeeded>(); // Bypasses Sqlite with in-memory DB
            else if (Environment.IsProduction())
                services.AddSingleton<IUnitOfWork, UnitOfWork>();
            else
                throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }

        private static Action<ITypedRouteBuilder> RoutesConfiguration(string baseUri)
        {
            return routes =>
            {
                routes.Add(baseUri + "patient/", route => route.ToController<PatientController>());
                routes.Add(baseUri + "visit/", route => route.ToController<VisitController>());
                ConfigureDataRoutes(baseUri, routes);
                ConfigureAnalyticsRoutes(baseUri, routes);
                
            };
        }

        private static void ConfigureAnalyticsRoutes(string baseUri, ITypedRouteBuilder routes)
        {
            var classifyUri = baseUri + "classify/";
            routes.Add(classifyUri, route => route.ToController<ClassifyController>());
            routes.Post("audiogram/", route => route.ToAction<ClassifyController>(a => a.PostToAudiogram(With.Any<Audiogram>())));
            routes.Post("bp/", route => route.ToAction<ClassifyController>(a => a.PostToBloodPressure(With.Any<BloodPressure>())));
            routes.Post("bodycomp/", route => route.ToAction<ClassifyController>(a => a.PostToBodyComposition(With.Any<BodyCompositionClassificationParameters>())));
            routes.Post("bodycompexp/", route => route.ToAction<ClassifyController>(a => a.PostToBodyCompositionExpanded(With.Any<BodyCompositionExpandedClassificationParameters>())));
            
            var compositeScoresUri = classifyUri + "composite/";
            routes.Add(compositeScoresUri, route => route.ToController<CompositeScoresController>());
        }

        private static void ConfigureDataRoutes(string baseUri, ITypedRouteBuilder routes)
        {
            var dataUri = baseUri + "data/";
            routes.Add(dataUri + "audiogram", route => route.ToController<AudiogramController>());
            routes.Add(dataUri + "bp/", route => route.ToController<BloodPressureController>());
            routes.Add(dataUri + "bodycomp/", route => route.ToController<BodyCompositionController>());
            routes.Add(dataUri + "bodycompexp/", route => route.ToController<BodyCompositionExpandedController>());
            routes.Add(dataUri + "carotidultrasound/", route => route.ToController<CarotidUltrasoundController>());
            routes.Add(dataUri + "centralbp/", route => route.ToController<CentralBloodPressureController>());
            routes.Add(dataUri + "fms/", route => route.ToController<FunctionalMovementScreenController>());
            routes.Add(dataUri + "grip/", route => route.ToController<GripStrengthController>());
            routes.Add(dataUri + "ishihara/", route => route.ToController<IshiharaSixPlateController>());
            routes.Add(dataUri + "occularpressure/", route => route.ToController<OccularPressureController>());
            routes.Add(dataUri + "peripheralvision/", route => route.ToController<PeripheralVisionController>());
            routes.Add(dataUri + "pushups/", route => route.ToController<PushupController>());
            routes.Add(dataUri + "sitandreach/", route => route.ToController<SitAndReachController>());
            routes.Add(dataUri + "situps/", route => route.ToController<SitupsController>());
            routes.Add(dataUri + "spirometry/", route => route.ToController<SpirometryController>());
            routes.Add(dataUri + "treadmill/", route => route.ToController<TreadmillExerciseStressTestController>());
            routes.Add(dataUri + "visualacuity/", route => route.ToController<VisualAcuityController>());
            routes.Add(dataUri + "vitals/", route => route.ToController<VitalSignsController>());

            var patientActivitiesUri = dataUri + "activities/";
            routes.Add(patientActivitiesUri + "resistance", route => route.ToController<ResistanceRegimenController>());
            routes.Add(patientActivitiesUri + "cardio", route => route.ToController<CardiovascularRegimenController>());
            routes.Add(patientActivitiesUri + "stretching", route => route.ToController<StretchingRegimenController>());
            
       }
    }
}
