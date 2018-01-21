using System.Collections.Generic;
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
        private readonly IUrlHelper _urlHelper;
        private readonly IConfiguration _configuration;

        public DataController(IUrlHelper urlHelper, IConfiguration configuration)
        {
            _configuration = configuration;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var nav = new ApiNavigationStructure
            {
                Title = "Data",
                Description = "This is persisted patient visit data, not including patients and visits themselves.",
                Links = new ApiLinks
                {
                    BloodPressures = new ResourceLink
                    {
                        Description = "Blood pressure resource data for patient visits. Can be filtered and paginated as follows...",
                        Href = _urlHelper.Action<BloodPressureController>(a => a.GetBySearch(null)),
                        HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get },
                        Relationship = UrlRelationship.Next
                    } 
                }
            };
            return Ok(nav);
        }
        
        private class ApiNavigationStructure
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public ApiLinks Links { get; set; }

            public ApiNavigationStructure()
            {
                Links = new ApiLinks();
            }
            
        }

        private class ApiLinks
        {
            public ResourceLink BloodPressures { get; set; }

        }
    }
}