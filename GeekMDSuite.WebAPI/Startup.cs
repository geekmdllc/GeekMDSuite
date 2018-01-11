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
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using With = Microsoft.AspNetCore.Builder.With;

namespace GeekMDSuite.WebAPI
{
    public partial class Startup
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
            

            services.AddMvc()
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters()
                .AddTypedRouting(RoutesConfiguration());
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
    }
}
