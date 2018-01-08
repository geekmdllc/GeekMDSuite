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

        private static Action<ITypedRouteBuilder> RoutesConfiguration(string baseUri)
        {
            return routes =>
            {
                routes.Get(baseUri + "audiogram/", route => route.ToController<AudiogramController>());
                routes.Get(baseUri + "bp/", route => route.ToController<BloodPressureController>());
                routes.Get(baseUri + "bodycomp/", route => route.ToController<BodyCompositionController>());
                routes.Get(baseUri + "bodycompplus/", route => route.ToController<BodyCompositionExpandedController>());
                routes.Get(baseUri + "carotidultrasound/", route => route.ToController<CarotidUltrasoundController>());
                routes.Get(baseUri + "centralbp/", route => route.ToController<CentralBloodPressureController>());
                routes.Get(baseUri + "fms/", route => route.ToController<FunctionalMovementScreenController>());
                routes.Get(baseUri + "grip/", route => route.ToController<GripStrengthController>());
                routes.Get(baseUri + "ishihara/", route => route.ToController<IshiharaSixPlateController>());
                routes.Get(baseUri + "occularpressure/", route => route.ToController<OccularPressureController>());
                routes.Get(baseUri + "patient/", route => route.ToController<PatientController>());
                routes.Get(baseUri + "peripheralvision/", route => route.ToController<PeripheralVisionController>());
                routes.Get(baseUri + "pushups/", route => route.ToController<PushupController>());
                routes.Get(baseUri + "sitandreach/", route => route.ToController<SitAndReachController>());
                routes.Get(baseUri + "situps/", route => route.ToController<SitupsController>());
                routes.Get(baseUri + "spirometry/", route => route.ToController<SpirometryController>());
                routes.Get(baseUri + "treadmill/", route => route.ToController<TreadmillExerciseStressTestController>());
                routes.Get(baseUri + "visit/", route => route.ToController<VisitController>());
                routes.Get(baseUri + "visualacuity/", route => route.ToController<VisualAcuityController>());
                routes.Get(baseUri + "vitals/", route => route.ToController<VitalSignsController>());
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}