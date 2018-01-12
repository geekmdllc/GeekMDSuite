using System;
using AspNet.Mvc.TypedRouting.Routing;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using Microsoft.AspNetCore.Builder;

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
                ConfigureDataRoutes(baseUrl, routes);
                ConfigureAnalyticsRoutes(baseUrl, routes);
            };
        }

        private static void ConfigurePatientControllerRoutes(string baseUrl,
            ITypedRouteBuilder routes)
        {
            routes.Add(baseUrl + "patient/", 
                route => route.ToController<PatientController>());
            routes.Get("", 
                route => route.ToAction<PatientController>(a => a.Search(With.Any<PatientDataSearchFilter>())));
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
                route => route.ToAction<VisitController>(a => a.Search(With.Any<VisitDataSearchFilter>())));
            routes.Get("{guid}",
                route => route.ToAction<VisitController>(a => a.GetByVisitGuid(With.Any<Guid>())));
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

        private static void ConfigureDataRoutes(string baseUrl, ITypedRouteBuilder routes)
        {
            var dataUri = baseUrl + "data/";
            routes.Add(dataUri + "audiogram/", route => route.ToController<AudiogramController>());
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