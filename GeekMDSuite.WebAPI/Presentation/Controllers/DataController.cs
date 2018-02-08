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
                        Description = "Blood pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<BloodPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    Audiograms = new ResourceLink
                    {
                        Description = "Audiogram resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<AudiogramsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    CarotidUltrasounds = new ResourceLink
                    {
                        Description = "Carotid ultrasound resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<CarotidUltrasoundsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    } ,
                    CentralBloodPressures = new ResourceLink
                    {
                        Description = "Central blood pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<CentralBloodPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    FunctionalMovementScreens = new ResourceLink
                    {
                        Description = "Functional Movement Screen resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<FunctionalMovementScreensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    GripStrengths = new ResourceLink
                    {
                        Description = "Grip strength resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<GripStrengthsController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    IshiharaSixPlateScreens = new ResourceLink
                    {
                        Description = "Ishihara six plate screens resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<IshiharaSixPlateScreensController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    OccularPressures = new ResourceLink
                    {
                        Description = "Occular pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<OccularPressuresController>(a => a.GetBySearch(null)),
                        HtmlMethod = HtmlMethod.Get,
                        Relationship = UrlRelationship.Next
                    },
                    PeripheralVisions = new ResourceLink
                    {
                        Description = "Peripheral visions resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = Url.Action<PeripheralVisionsController>(a => a.GetBySearch(null)),
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
            public ResourceLink BloodPressures { get; set; }
            public ResourceLink CarotidUltrasounds { get; set; }
            public ResourceLink CentralBloodPressures { get; set; }
            public ResourceLink FunctionalMovementScreens { get; set; }
            public ResourceLink GripStrengths { get; set; }
            public ResourceLink IshiharaSixPlateScreens { get; set; }
            public ResourceLink OccularPressures { get; set; }
            public ResourceLink PeripheralVisions { get; set; }
        }
    }
}