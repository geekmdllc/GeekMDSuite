using AspNet.Mvc.TypedRouting.Routing;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using Microsoft.AspNetCore.Builder;
using System;
using GeekMDSuite.WebAPI.Presentation.Controllers.PatientController;

namespace GeekMDSuite.WebAPI
{
    public partial class Startup
    {
        private Action<ITypedRouteBuilder> RoutesConfiguration()
        {
            var baseUrl = Configuration.GetSection("ApiBaseUrl").Value;

            return routes =>
            {
                ConfigurePatientControllerRoutes(baseUrl, routes);
                ConfigureVisitControllerRoutes(baseUrl, routes);
                ConfigureAnalyticsRoutes(baseUrl, routes);
                routes.Add(baseUrl + "bp/", route => route.ToController<BloodPressureController>());
                routes.Get("", route => route.ToAction<BloodPressureController>(a => a.Get()));
            };
        }

        private static void ConfigurePatientControllerRoutes(string baseUrl,
            ITypedRouteBuilder routes)
        {
            routes.Add(baseUrl + "patient/",
                route => route.ToController<PatientController>());
            routes.Get("",
                route => route.ToAction<PatientController>(a => a.GetBySearch(With.Any<PatientDataSearchFilter>())));
            routes.Get("{guid}/visits",
                route => route.ToAction<PatientController>(a => a.GetVisits(With.Any<Guid>())));
            routes.Get("{guid}",
                route => route.ToAction<PatientController>(a => a.GetByGuid(With.Any<Guid>())));
        }

        private static void ConfigureVisitControllerRoutes(string baseUrl,
            ITypedRouteBuilder routes)
        {
            routes.Add(baseUrl + "visit/",
                route => route.ToController<VisitController>());
            routes.Get("",
                route => route.ToAction<VisitController>(a => a.GetBySearch(With.Any<VisitDataSearchFilter>())));
            routes.Get("{guid}",
                route => route.ToAction<VisitController>(a => a.GetByGuid(With.Any<Guid>())));
        }

        private static void ConfigureAnalyticsRoutes(string baseUrl, ITypedRouteBuilder routes)
        {
            var classifyUri = baseUrl + "classify/";
            routes.Add(classifyUri, route => route.ToController<ClassifyController>());
            routes.Post("audiogram/",
                route => route.ToAction<ClassifyController>(a => a.PostToAudiogram(With.Any<Audiogram>())));
            routes.Post("bp/",
                route => route.ToAction<ClassifyController>(a => a.PostToBloodPressure(With.Any<BloodPressure>())));
            routes.Post("bodycomp/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToBodyComposition(With.Any<BodyCompositionClassificationParameters>())));
            routes.Post("bodycompexp/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToBodyCompositionExpanded(With.Any<BodyCompositionExpandedClassificationParameters>())));

            var compositeScoresUri = classifyUri + "composite/";
            routes.Add(compositeScoresUri, route => route.ToController<CompositeScoresController>());
        }

    }
}