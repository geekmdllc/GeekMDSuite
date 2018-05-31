using System;
using AspNet.Mvc.TypedRouting.Routing;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers.CompositeScores;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using GeekMDSuite.WebAPI.Presentation.Controllers.PatientController;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
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
            routes.Add(baseUrl + "patient/", route => route.ToController<PatientController>());
            routes.Get("",
                route => route.ToAction<PatientController>(a => a.GetBySearch(With.Any<PatientDataSearchFilter>())));
            routes.Get("{guid}/visits", route => route.ToAction<PatientController>(a => a.GetVisits(With.Any<Guid>())));
            routes.Get("{guid}", route => route.ToAction<PatientController>(a => a.GetByGuid(With.Any<Guid>())));
        }

        private static void ConfigureVisitControllerRoutes(string baseUrl,
            ITypedRouteBuilder routes)
        {
            routes.Add(baseUrl + "visit/", route => route.ToController<VisitController>());
            routes.Get("",
                route => route.ToAction<VisitController>(a => a.GetBySearch(With.Any<VisitDataSearchFilter>())));
            routes.Get("{guid}", route => route.ToAction<VisitController>(a => a.GetByGuid(With.Any<Guid>())));
        }

        private static void ConfigureAnalyticsRoutes(string baseUrl, ITypedRouteBuilder routes)
        {
            var classifyUri = baseUrl + "analytics/";
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
            routes.Post("carotidus/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToCarotidUltrasound(With.Any<CarotidUltrasound>())));
            routes.Post("cardioregimen/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToCardiovascularRegimen(With.Any<CardiovascularRegimen>())));
            routes.Post("centralbp/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToCentralBloodPressure(With.Any<CentralBloodPressureParameters>())));
            routes.Post("fms/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToFunctionalMovementScreen(With.Any<FunctionalMovementScreen>())));
            routes.Post("gripstrength/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToGripStrength(With.Any<GripStrengthClassificationParameters>())));
            routes.Post("ishiharasixplate/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToIshiharaSixPlateScreen(With.Any<IshiharaSixPlate>())));
            routes.Post("occularpressure/",
                route => route.ToAction<ClassifyController>(a => a.PostToOccularPressure(With.Any<OccularPressure>())));
            routes.Post("peripheralvision/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToPeripheralVision(With.Any<PeripheralVision>())));
            routes.Post("pushups/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToPushups(With.Any<PushupsClassificationParameters>())));
            routes.Post("qualitativelab/",
                route => route.ToAction<ClassifyController>(a => a.PostToQualitativeLabs(With.Any<QualitativeLab>())));
            routes.Post("quantitativelab/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToQuantitativeLabs(With.Any<QuantitativeLabClassificationParameters>())));
            routes.Post("resistanceregimen/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToResistanceRegimen(With.Any<ResistanceRegimen>())));
            routes.Post("situps/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToSitAndReach(With.Any<SitAndReachClassificationParameters>())));
            routes.Post("sitandreach/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToSitups(With.Any<SitupsClassificationParameters>())));
            routes.Post("spirometry/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToSpirometry(With.Any<SpirometryClassificationParameters>())));
            routes.Post("stretchingregimen/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToStretchingRegimen(With.Any<StretchingRegimen>())));
            routes.Post("fitscore/",
                route => route.ToAction<ClassifyController>(a =>
                    a.PostToFitTreadmillScore(With.Any<TreadmillExerciseStressTestClassificationParameters>())));
            routes.Post("visualacuity/",
                route => route.ToAction<ClassifyController>(a => a.PostToVisualAcuity(With.Any<VisualAcuity>())));

            var compositeScoresUri = classifyUri + "composite/";
            routes.Add(compositeScoresUri, route => route.ToController<CompositeScoresController>());
        }

        private static void ConfigureDataRoutes(string baseUrl, ITypedRouteBuilder routes)
        {
            var dataUrl = baseUrl + "data/";

            routes.Add(dataUrl + "audiogram/", route => route.ToController<AudiogramsController>());
            routes.Get("",
                route => route.ToAction<AudiogramsController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<AudiogramsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<AudiogramsController>(a => a.Post(With.Any<AudiogramStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<AudiogramsController>(a =>
                    a.Put(With.Any<int>(), With.Any<AudiogramStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<AudiogramsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "bp/", route => route.ToController<BloodPressuresController>());
            routes.Get("",
                route => route.ToAction<BloodPressuresController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<BloodPressuresController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<BloodPressuresController>(a => a.Post(With.Any<BloodPressureStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<BloodPressuresController>(a =>
                    a.Put(With.Any<int>(), With.Any<BloodPressureStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<BloodPressuresController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "bodycomp/", route => route.ToController<BodyCompositionsController>());
            routes.Get("",
                route => route.ToAction<BodyCompositionsController>(
                    a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<BodyCompositionsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<BodyCompositionsController>(
                    a => a.Post(With.Any<BodyCompositionStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<BodyCompositionsController>(a =>
                    a.Put(With.Any<int>(), With.Any<BodyCompositionStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<BodyCompositionsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "bodycompexpandeds/",
                route => route.ToController<BodyCompositionExpandedsController>());
            routes.Get("",
                route => route.ToAction<BodyCompositionExpandedsController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<BodyCompositionExpandedsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<BodyCompositionExpandedsController>(a =>
                    a.Post(With.Any<BodyCompositionExpandedStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<BodyCompositionExpandedsController>(a =>
                    a.Put(With.Any<int>(), With.Any<BodyCompositionExpandedStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<BodyCompositionExpandedsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "cardioregimens/", route => route.ToController<CardiovascularRegimensController>());
            routes.Get("",
                route => route.ToAction<CardiovascularRegimensController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<CardiovascularRegimensController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<CardiovascularRegimensController>(a =>
                    a.Post(With.Any<CardiovascularRegimenStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<CardiovascularRegimensController>(a =>
                    a.Put(With.Any<int>(), With.Any<CardiovascularRegimenStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<CardiovascularRegimensController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "carotidus/", route => route.ToController<CarotidUltrasoundsController>());
            routes.Get("",
                route => route.ToAction<CarotidUltrasoundsController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<CarotidUltrasoundsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<CarotidUltrasoundsController>(a =>
                    a.Post(With.Any<CarotidUltrasoundStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<CarotidUltrasoundsController>(a =>
                    a.Put(With.Any<int>(), With.Any<CarotidUltrasoundStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<CarotidUltrasoundsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "centralbp/", route => route.ToController<CentralBloodPressuresController>());
            routes.Get("",
                route => route.ToAction<CentralBloodPressuresController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<CentralBloodPressuresController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<CentralBloodPressuresController>(a =>
                    a.Post(With.Any<CentralBloodPressureStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<CentralBloodPressuresController>(a =>
                    a.Put(With.Any<int>(), With.Any<CentralBloodPressureStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<CentralBloodPressuresController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "fms/", route => route.ToController<FunctionalMovementScreensController>());
            routes.Get("",
                route => route.ToAction<FunctionalMovementScreensController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<FunctionalMovementScreensController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<FunctionalMovementScreensController>(a =>
                    a.Post(With.Any<FunctionalMovementScreenStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<FunctionalMovementScreensController>(a =>
                    a.Put(With.Any<int>(), With.Any<FunctionalMovementScreenStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<FunctionalMovementScreensController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "gripstrength/", route => route.ToController<GripStrengthsController>());
            routes.Get("",
                route => route.ToAction<GripStrengthsController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<GripStrengthsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<GripStrengthsController>(a => a.Post(With.Any<GripStrengthStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<GripStrengthsController>(a =>
                    a.Put(With.Any<int>(), With.Any<GripStrengthStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<GripStrengthsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "ishihara/", route => route.ToController<IshiharaSixPlateScreensController>());
            routes.Get("",
                route => route.ToAction<IshiharaSixPlateScreensController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<IshiharaSixPlateScreensController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<IshiharaSixPlateScreensController>(a =>
                    a.Post(With.Any<IshiharaSixPlateStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<IshiharaSixPlateScreensController>(a =>
                    a.Put(With.Any<int>(), With.Any<IshiharaSixPlateStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<IshiharaSixPlateScreensController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "occularpressures/", route => route.ToController<OccularPressuresController>());
            routes.Get("",
                route => route.ToAction<OccularPressuresController>(
                    a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<OccularPressuresController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<OccularPressuresController>(
                    a => a.Post(With.Any<OccularPressureStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<OccularPressuresController>(a =>
                    a.Put(With.Any<int>(), With.Any<OccularPressureStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<OccularPressuresController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "peripheralvisions/", route => route.ToController<PeripheralVisionsController>());
            routes.Get("",
                route => route.ToAction<PeripheralVisionsController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<PeripheralVisionsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<PeripheralVisionsController>(a =>
                    a.Post(With.Any<PeripheralVisionStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<PeripheralVisionsController>(a =>
                    a.Put(With.Any<int>(), With.Any<PeripheralVisionStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<PeripheralVisionsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "pushups/", route => route.ToController<PushupsController>());
            routes.Get("",
                route => route.ToAction<PushupsController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<PushupsController>(a => a.GetById(With.Any<int>())));
            routes.Post("", route => route.ToAction<PushupsController>(a => a.Post(With.Any<PushupsStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<PushupsController>(a =>
                    a.Put(With.Any<int>(), With.Any<PushupsStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<PushupsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "qualitativelabs/", route => route.ToController<QualitativeLabsController>());
            routes.Get("",
                route => route.ToAction<QualitativeLabsController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<QualitativeLabsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<QualitativeLabsController>(a =>
                    a.Post(With.Any<QualitativeLabsStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<QualitativeLabsController>(a =>
                    a.Put(With.Any<int>(), With.Any<QualitativeLabsStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<QualitativeLabsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "quantitativelabs/", route => route.ToController<QuantitativeLabsController>());
            routes.Get("",
                route => route.ToAction<QuantitativeLabsController>(
                    a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<QuantitativeLabsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<QuantitativeLabsController>(
                    a => a.Post(With.Any<QuantitativeLabStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<QuantitativeLabsController>(a =>
                    a.Put(With.Any<int>(), With.Any<QuantitativeLabStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<QuantitativeLabsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "resistanceregimens/", route => route.ToController<ResistanceRegimensController>());
            routes.Get("",
                route => route.ToAction<ResistanceRegimensController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<ResistanceRegimensController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<ResistanceRegimensController>(a =>
                    a.Post(With.Any<ResistanceRegimenStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<ResistanceRegimensController>(a =>
                    a.Put(With.Any<int>(), With.Any<ResistanceRegimenStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<ResistanceRegimensController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "sitandreaches/", route => route.ToController<SitAndReachesController>());
            routes.Get("",
                route => route.ToAction<SitAndReachesController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<SitAndReachesController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<SitAndReachesController>(a => a.Post(With.Any<SitAndReachStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<SitAndReachesController>(a =>
                    a.Put(With.Any<int>(), With.Any<SitAndReachStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<SitAndReachesController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "situps/", route => route.ToController<SitupsController>());
            routes.Get("",
                route => route.ToAction<SitupsController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<SitupsController>(a => a.GetById(With.Any<int>())));
            routes.Post("", route => route.ToAction<SitupsController>(a => a.Post(With.Any<SitupsStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<SitupsController>(a => a.Put(With.Any<int>(), With.Any<SitupsStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<SitupsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "spirometries/", route => route.ToController<SpirometriesController>());
            routes.Get("",
                route => route.ToAction<SpirometriesController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<SpirometriesController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<SpirometriesController>(a => a.Post(With.Any<SpirometryStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<SpirometriesController>(a =>
                    a.Put(With.Any<int>(), With.Any<SpirometryStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<SpirometriesController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "stretchingregimens/", route => route.ToController<StretchingRegimensController>());
            routes.Get("",
                route => route.ToAction<StretchingRegimensController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<StretchingRegimensController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<StretchingRegimensController>(a =>
                    a.Post(With.Any<StretchingRegimenStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<StretchingRegimensController>(a =>
                    a.Put(With.Any<int>(), With.Any<StretchingRegimenStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<StretchingRegimensController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "treadmills/", route => route.ToController<TreadmillExerciseStressTestsController>());
            routes.Get("",
                route => route.ToAction<TreadmillExerciseStressTestsController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}",
                route => route.ToAction<TreadmillExerciseStressTestsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<TreadmillExerciseStressTestsController>(a =>
                    a.Post(With.Any<TreadmillExerciseStressTestStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<TreadmillExerciseStressTestsController>(a =>
                    a.Put(With.Any<int>(), With.Any<TreadmillExerciseStressTestStubFromUser>())));
            routes.Delete("{id}",
                route => route.ToAction<TreadmillExerciseStressTestsController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "visualacuities/", route => route.ToController<VisualAcuitiesController>());
            routes.Get("",
                route => route.ToAction<VisualAcuitiesController>(a =>
                    a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<VisualAcuitiesController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<VisualAcuitiesController>(a => a.Post(With.Any<VisualAcuityStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<VisualAcuitiesController>(a =>
                    a.Put(With.Any<int>(), With.Any<VisualAcuityStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<VisualAcuitiesController>(a => a.Delete(With.Any<int>())));

            routes.Add(dataUrl + "vitalsigns/", route => route.ToController<VitalSignsController>());
            routes.Get("",
                route => route.ToAction<VitalSignsController>(a => a.GetBySearch(With.Any<EntityDataFindFilter>())));
            routes.Get("{id}", route => route.ToAction<VitalSignsController>(a => a.GetById(With.Any<int>())));
            routes.Post("",
                route => route.ToAction<VitalSignsController>(a => a.Post(With.Any<VitalSignsStubFromUser>())));
            routes.Put("{id}",
                route => route.ToAction<VitalSignsController>(a =>
                    a.Put(With.Any<int>(), With.Any<VitalSignsStubFromUser>())));
            routes.Delete("{id}", route => route.ToAction<VitalSignsController>(a => a.Delete(With.Any<int>())));
        }
    }
}