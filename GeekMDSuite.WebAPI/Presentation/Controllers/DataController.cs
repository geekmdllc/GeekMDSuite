using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("app/rest/data")]
    [Produces("application/json", "application/xml")]
    public class DataController : Controller
    {
        private readonly IConfiguration _configuration;

        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var nav = new ApiDirectoryNavigationModel<DataLinks>
            {
                Title = "Data",
                Description = "This is persisted patient visit data, not including patients and visits themselves.",
                Links = new DataLinks
                {
                    Home = new ResourceLink
                    {
                        Description = "Go to application root.",
                        Href = Url.Action<HomeController>(a => a.Get()),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    BloodPressures = new ResourceLink
                    {
                        Description =
                            "Blood pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<BloodPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    BodyCompositions = new ResourceLink
                    {
                        Description =
                            "Body compositions resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<BodyCompositionsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    BodyCompositionExpandeds = new ResourceLink
                    {
                        Description =
                            "Body composition expandeds resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<BodyCompositionExpandedsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Audiograms = new ResourceLink
                    {
                        Description =
                            "Audiogram resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<AudiogramsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    CardiovascularRegimen = new ResourceLink
                    {
                        Description =
                            "Cardiovascular regimens resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<CardiovascularRegimensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    CarotidUltrasounds = new ResourceLink
                    {
                        Description =
                            "Carotid ultrasound resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<CarotidUltrasoundsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    CentralBloodPressures = new ResourceLink
                    {
                        Description =
                            "Central blood pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<CentralBloodPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    FunctionalMovementScreens = new ResourceLink
                    {
                        Description =
                            "Functional Movement Screen resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<FunctionalMovementScreensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    GripStrengths = new ResourceLink
                    {
                        Description =
                            "Grip strength resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<GripStrengthsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    IshiharaSixPlateScreens = new ResourceLink
                    {
                        Description =
                            "Ishihara six plate screens resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<IshiharaSixPlateScreensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    OccularPressures = new ResourceLink
                    {
                        Description =
                            "Occular pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<OccularPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    PeripheralVisions = new ResourceLink
                    {
                        Description =
                            "Peripheral visions resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<PeripheralVisionsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Pushups = new ResourceLink
                    {
                        Description =
                            "Pushups resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<PushupsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    QualitativeLabs = new ResourceLink
                    {
                        Description =
                            "Qualitative labs resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<QualitativeLabsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    QuantitativeLabs = new ResourceLink
                    {
                        Description =
                            "Quantitative labs resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<QuantitativeLabsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    ResistanceRegimens = new ResourceLink
                    {
                        Description =
                            "Resistance regimens resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<ResistanceRegimensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    SitAndReaches = new ResourceLink
                    {
                        Description =
                            "Sit and reaches resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<SitAndReachesController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Situps = new ResourceLink
                    {
                        Description =
                            "Situps resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<SitupsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Spirometries = new ResourceLink
                    {
                        Description =
                            "Spirometries resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<SpirometriesController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    StretchingRegimens = new ResourceLink
                    {
                        Description =
                            "Stretching regimens resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<StretchingRegimensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    TreadmillExerciseStressTests = new ResourceLink
                    {
                        Description =
                            "Treadmill exercises stress tests resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<TreadmillExerciseStressTestsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    VisualAcuities = new ResourceLink
                    {
                        Description =
                            "Visual acuities resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<VisualAcuitiesController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    VitalSigns = new ResourceLink
                    {
                        Description =
                            "Vital signs resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<VitalSignsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    }
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