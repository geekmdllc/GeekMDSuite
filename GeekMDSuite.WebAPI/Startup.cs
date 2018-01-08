using System;
using AspNet.Mvc.TypedRouting.Routing;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            const string baseUri = "app/rest/";

            services.AddMvc()
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters()
                .AddTypedRouting(RoutesConfiguration(baseUri));
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
                routes.Get(baseUri + "patient/", route => route.ToController<PatientController>());
                routes.Get(baseUri + "visit/", route => route.ToController<VisitController>());
                ConfigureDataRoutes(baseUri, routes);
                ConfigureAnalyticsRoutes(baseUri, routes);
            };
        }

        private static void ConfigureAnalyticsRoutes(string baseUri, ITypedRouteBuilder routes)
        {
            var classifyUri = baseUri + "classify/"; 
            routes.Get(classifyUri, route => route.ToController<ClassifiyController>());
            routes.Get(classifyUri + "composite/", route => route.ToController<CompositeScoresController>());
        }

        private static void ConfigureDataRoutes(string baseUri, ITypedRouteBuilder routes)
        {
            var dataUri = baseUri + "data/";
            routes.Get(dataUri + "audiogram/", route => route.ToController<AudiogramController>());
            routes.Get(dataUri + "bp/", route => route.ToController<BloodPressureController>());
            routes.Get(dataUri + "bodycomp/", route => route.ToController<BodyCompositionController>());
            routes.Get(dataUri + "bodycompplus/", route => route.ToController<BodyCompositionExpandedController>());
            routes.Get(dataUri + "carotidultrasound/", route => route.ToController<CarotidUltrasoundController>());
            routes.Get(dataUri + "centralbp/", route => route.ToController<CentralBloodPressureController>());
            routes.Get(dataUri + "fms/", route => route.ToController<FunctionalMovementScreenController>());
            routes.Get(dataUri + "grip/", route => route.ToController<GripStrengthController>());
            routes.Get(dataUri + "ishihara/", route => route.ToController<IshiharaSixPlateController>());
            routes.Get(dataUri + "occularpressure/", route => route.ToController<OccularPressureController>());
            routes.Get(dataUri + "peripheralvision/", route => route.ToController<PeripheralVisionController>());
            routes.Get(dataUri + "pushups/", route => route.ToController<PushupController>());
            routes.Get(dataUri + "sitandreach/", route => route.ToController<SitAndReachController>());
            routes.Get(dataUri + "situps/", route => route.ToController<SitupsController>());
            routes.Get(dataUri + "spirometry/", route => route.ToController<SpirometryController>());
            routes.Get(dataUri + "treadmill/", route => route.ToController<TreadmillExerciseStressTestController>());
            routes.Get(dataUri + "visualacuity/", route => route.ToController<VisualAcuityController>());
            routes.Get(dataUri + "vitals/", route => route.ToController<VitalSignsController>());
        }
    }
}
