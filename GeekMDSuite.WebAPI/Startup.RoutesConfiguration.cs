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
using System;
using GeekMDSuite.WebAPI.Presentation.Controllers.PatientController;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;

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

        private static void ConfigureDataRoutes(string baseUrl, ITypedRouteBuilder routes)
        {
            var dataUrl = baseUrl + "data/";
            
            routes.Add(dataUrl + "audiogram/", route => route.ToController<AudiogramController>());
            routes.Get("", route => route.ToAction<AudiogramController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<AudiogramController>(a => a.GetById(With.Any<int>())));
            routes.Post("", route => route.ToAction<AudiogramController>(a => a.Post(With.Any<AudiogramStubFromUser>())));
            routes.Put("{id}", route => route.ToAction<AudiogramController>(a => a.Put(With.Any<int>(), With.Any<AudiogramStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<AudiogramController>(a => a.Delete(With.Any<int>())));
            
            routes.Add(dataUrl + "bp/", route => route.ToController<BloodPressureController>());
            routes.Get("", route => route.ToAction<BloodPressureController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<BloodPressureController>(a => a.GetById(With.Any<int>())));
            routes.Post("", route => route.ToAction<BloodPressureController>(a => a.Post(With.Any<BloodPressureStubFromUser>())));
            routes.Put("{id}", route => route.ToAction<BloodPressureController>(a => a.Put(With.Any<int>(), With.Any<BloodPressureStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<BloodPressureController>(a => a.Delete(With.Any<int>())));
            
            routes.Add(dataUrl + "carotidus/", route => route.ToController<CarotidUltrasoundController>());
            routes.Get("", route => route.ToAction<CarotidUltrasoundController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<CarotidUltrasoundController>(a => a.GetById(With.Any<int>())));
            routes.Post("", route => route.ToAction<CarotidUltrasoundController>(a => a.Post(With.Any<CarotidUltrasoundStubFromUser>())));
            routes.Put("{id}", route => route.ToAction<CarotidUltrasoundController>(a => a.Put(With.Any<int>(), With.Any<CarotidUltrasoundStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<CarotidUltrasoundController>(a => a.Delete(With.Any<int>())));
            
//            routes.Add(dataUrl + "bodycomp/", route => route.ToController<BodyCompositionController>());
//            routes.Add(dataUrl + "bodycompexp/", route => route.ToController<BodyCompositionExpandedController>());
//            routes.Add(dataUrl + "centralbp/", route => route.ToController<CentralBloodPressureController>());
//            routes.Add(dataUrl + "fms/", route => route.ToController<FunctionalMovementScreenController>());
//            routes.Add(dataUrl + "grip/", route => route.ToController<GripStrengthController>());
//            routes.Add(dataUrl + "ishihara/", route => route.ToController<IshiharaSixPlateController>());
//            routes.Add(dataUrl + "occularpressure/", route => route.ToController<OccularPressureController>());
//            routes.Add(dataUrl + "peripheralvision/", route => route.ToController<PeripheralVisionController>());
//            routes.Add(dataUrl + "pushups/", route => route.ToController<PushupController>());
//            routes.Add(dataUrl + "sitandreach/", route => route.ToController<SitAndReachController>());
//            routes.Add(dataUrl + "situps/", route => route.ToController<SitupsController>());
//            routes.Add(dataUrl + "spirometry/", route => route.ToController<SpirometryController>());
//            routes.Add(dataUrl + "treadmill/", route => route.ToController<TreadmillExerciseStressTestController>());
//            routes.Add(dataUrl + "visualacuity/", route => route.ToController<VisualAcuityController>());
//            routes.Add(dataUrl + "vitals/", route => route.ToController<VitalSignsController>());
//
//            var patientActivitiesUri = dataUrl + "activities/";
//            routes.Add(patientActivitiesUri + "resistance", route => route.ToController<ResistanceRegimenController>());
//            routes.Add(patientActivitiesUri + "cardio", route => route.ToController<CardiovascularRegimenController>());
//            routes.Add(patientActivitiesUri + "stretching", route => route.ToController<StretchingRegimenController>());
        }
    }
}