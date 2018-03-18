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
        public IActionResult Get()
        {
            var nav = new ApiDirectoryNavigationModel<DataLinks>()
            {
                
                Title = "Analytics",
                Description = "Perform analytics on patient data.",
                Links = new DataLinks
                {
                    // Links go here.
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
                    BodyCompositions =  new ResourceLink
                    {
                        Description = "Interpet body compositions. This is WITHOUT body fat percentage and visceral fat content.",
                        Href = Url.Action<ClassifyController>(a => a.PostToBodyComposition(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    BodyCompositionExpandeds = new ResourceLink
                    {
                        Description = "Interpet body compositions, including body fat percentage and visceral fat content.",
                        Href = Url.Action<ClassifyController>(a => a.PostToBodyCompositionExpanded(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    BloodPressures = new ResourceLink
                    {
                        Description = "Interpret blood pressures",
                        Href = Url.Action<ClassifyController>(a => a.PostToBloodPressure(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    CarotidUltrasounds = new ResourceLink
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
                    CentralBloodPressures = new ResourceLink
                    {
                        Description = "Interpret a patients central blood pressures",
                        Href = Url.Action<ClassifyController>(a => a.PostToCentralBloodPressure(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    FunctionalMovementScreens = new ResourceLink
                    {
                        Description = "Interpret a patients Funtional Movement Screen",
                        Href = Url.Action<ClassifyController>(a => a.PostToFunctionalMovementScreen(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                    GripStrengths = new ResourceLink
                    {
                        Description = "Interpret a patients grip strength",
                        Href = Url.Action<ClassifyController>(a => a.PostToGripStrength(null)),
                        HtmlMethod = HtmlMethod.Post,
                        Relationship = UrlRelationship.Next
                    },
                }
            };

            return Ok(nav);
        }
        private class DataLinks
        {
            public ResourceLink Home { get; set; }
            public ResourceLink Audiograms { get; set; }
            public ResourceLink BodyCompositions { get; set; }
            public ResourceLink BodyCompositionExpandeds { get; set; }
            public ResourceLink BloodPressures { get; set; }
            public ResourceLink CardiovascularRegimen { get; set; }
            public ResourceLink CarotidUltrasounds { get; set; }
            public ResourceLink CentralBloodPressures { get; set; }
            public ResourceLink FunctionalMovementScreens { get; set; }
            public ResourceLink GripStrengths { get; set; }
            public ResourceLink IshiharaSixPlateScreens { get; set; }
            public ResourceLink OccularPressures { get; set; }
            public ResourceLink PeripheralVisions { get; set; }
            public ResourceLink Pushups { get; set; }
            public ResourceLink QualitativeLabs { get; set; }
            public ResourceLink QuantitativeLabs { get; set; }
            public ResourceLink ResistanceRegimens { get; set; }
            public ResourceLink SitAndReaches { get; set; }
            public ResourceLink Situps { get; set; }
            public ResourceLink Spirometries { get; set; }
            public ResourceLink StretchingRegimens { get; set; }
            public ResourceLink TreadmillExerciseStressTests { get; set; }
            public ResourceLink VisualAcuities { get; set; }
            public ResourceLink VitalSigns { get; set; }
        }
    }
}