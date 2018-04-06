using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("app/rest/analytics")]
    [Produces("application/json", "application/xml")]
    public class AnalyticsController : Controller
    {
        private readonly IConfiguration _configuration;

        public AnalyticsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public IActionResult Get() => Ok(BuildApiDirectoryNavigationModel());

        private ApiDirectoryNavigationModel<DataLinks> BuildApiDirectoryNavigationModel()
        {
            var nav = new ApiDirectoryNavigationModel<DataLinks>()
            {
                Title = "Analytics",
                Description = "Perform analytics on patient data.",
                Links = new DataLinks
                {
                    Home = new ResourceLink
                    {
                        Description = "Go to application root.",
                        Href = Url.Action<HomeController>(a => a.Get()),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Audiograms = new ResourceLink
                    {
                        Description = "Interpret audiograms.",
                        Href = Url.Action<ClassifyController>(a => a.PostToAudiogram(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    BodyComposition = new ResourceLink
                    {
                        Description =
                            "Interpet body compositions. This is WITHOUT body fat percentage and visceral fat content.",
                        Href = Url.Action<ClassifyController>(a => a.PostToBodyComposition(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    BodyCompositionExpanded = new ResourceLink
                    {
                        Description = "Interpet body compositions, including body fat percentage and visceral fat content.",
                        Href = Url.Action<ClassifyController>(a => a.PostToBodyCompositionExpanded(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    BloodPressure = new ResourceLink
                    {
                        Description = "Interpret blood pressures",
                        Href = Url.Action<ClassifyController>(a => a.PostToBloodPressure(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    CarotidUltrasound = new ResourceLink
                    {
                        Description = "Interpret a patients carotid ultrasound",
                        Href = Url.Action<ClassifyController>(a => a.PostToCarotidUltrasound(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    CardiovascularRegimen = new ResourceLink
                    {
                        Description = "Interpret a patients cardiovascular regimen",
                        Href = Url.Action<ClassifyController>(a => a.PostToCardiovascularRegimen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    CentralBloodPressure = new ResourceLink
                    {
                        Description = "Interpret a patients central blood pressures",
                        Href = Url.Action<ClassifyController>(a => a.PostToCentralBloodPressure(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    FunctionalMovementScreen = new ResourceLink
                    {
                        Description = "Interpret a patients Funtional Movement Screen",
                        Href = Url.Action<ClassifyController>(a => a.PostToFunctionalMovementScreen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    GripStrength = new ResourceLink
                    {
                        Description = "Interpret a patients grip strength",
                        Href = Url.Action<ClassifyController>(a => a.PostToGripStrength(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    IshiharaSixPlateScreen = new ResourceLink
                    {
                        Description = "Interpret a patients Ishihara six plate screen",
                        Href = Url.Action<ClassifyController>(a => a.PostToIshiharaSixPlateScreen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    OccularPressure = new ResourceLink
                    {
                        Description = "Interpret a patients occular pressure screen",
                        Href = Url.Action<ClassifyController>(a => a.PostToOccularPressure(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    PeripheralVision = new ResourceLink
                    {
                        Description = "Interpret a patients peripheral vision screen",
                        Href = Url.Action<ClassifyController>(a => a.PostToPeripheralVision(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    Pushups = new ResourceLink
                    {
                        Description = "Interpret a patients pushups",
                        Href = Url.Action<ClassifyController>(a => a.PostToPushups(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    QualitativeLab = new ResourceLink
                    {
                        Description = "Interpret a patients qualitative labs",
                        Href = Url.Action<ClassifyController>(a => a.PostToQualitativeLabs(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    QuantitativeLab = new ResourceLink
                    {
                        Description = "Interpret a patients quantitative labs",
                        Href = Url.Action<ClassifyController>(a => a.PostToQuantitativeLabs(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    ResistanceRegimen = new ResourceLink
                    {
                        Description = "Interpret a patients resistance regimen",
                        Href = Url.Action<ClassifyController>(a => a.PostToResistanceRegimen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    SitAndReach = new ResourceLink
                    {
                        Description = "Interpret a patients sit and reach test",
                        Href = Url.Action<ClassifyController>(a => a.PostToSitAndReach(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    Situps = new ResourceLink
                    {
                        Description = "Interpret a patients situps test",
                        Href = Url.Action<ClassifyController>(a => a.PostToSitups(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    Spirometry = new ResourceLink
                    {
                        Description = "Interpret a patients spirometry",
                        Href = Url.Action<ClassifyController>(a => a.PostToSpirometry(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    StretchingRegimen = new ResourceLink
                    {
                        Description = "Interpret a patients stretching regimen",
                        Href = Url.Action<ClassifyController>(a => a.PostToStretchingRegimen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    FitTreadmillScore = new ResourceLink
                    {
                        Description = "Interpret a patients Fit Treadmill Score",
                        Href = Url.Action<ClassifyController>(a => a.PostToFitTreadmillScore(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    VisualAcuity = new ResourceLink
                    {
                        Description = "Interpret a patients visual acuity",
                        Href = Url.Action<ClassifyController>(a => a.PostToVisualAcuity(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                }
            };
            return nav;
        }

        private class DataLinks
        {
            public ResourceLink Home { get; set; }
            public ResourceLink Audiograms { get; set; }
            public ResourceLink BodyComposition { get; set; }
            public ResourceLink BodyCompositionExpanded { get; set; }
            public ResourceLink BloodPressure { get; set; }
            public ResourceLink CardiovascularRegimen { get; set; }
            public ResourceLink CarotidUltrasound { get; set; }
            public ResourceLink CentralBloodPressure { get; set; }
            public ResourceLink FunctionalMovementScreen { get; set; }
            public ResourceLink GripStrength { get; set; }
            public ResourceLink IshiharaSixPlateScreen { get; set; }
            public ResourceLink OccularPressure { get; set; }
            public ResourceLink PeripheralVision { get; set; }
            public ResourceLink Pushups { get; set; }
            public ResourceLink QualitativeLab { get; set; }
            public ResourceLink QuantitativeLab { get; set; }
            public ResourceLink ResistanceRegimen { get; set; }
            public ResourceLink SitAndReach { get; set; }
            public ResourceLink Situps { get; set; }
            public ResourceLink Spirometry { get; set; }
            public ResourceLink StretchingRegimen { get; set; }
            public ResourceLink FitTreadmillScore { get; set; }
            public ResourceLink VisualAcuity { get; set; }
        }
    }
}