using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Route("app/rest")]
    [Produces("application/json", "application/xml")]
    public class HomeController : Controller
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IConfiguration _configuration;

        public HomeController(IUrlHelper urlHelper, IConfiguration configuration)
        {
            _configuration = configuration;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var navStructure = new ApiNavigationStructure
            {
                Title = $"{_configuration.GetSection("ApiTitle").Value} v{_configuration.GetSection("ApiVersion").Value}",
                Description = _configuration.GetSection("ApiDescription").Value,
                Links = new ApiLinks
                {
                    Patients = new ResourceLink
                    {
                        Description = _configuration.GetSection("PatientsControllerDescription").Value,
                        Href = _urlHelper.Action<PatientController.PatientController>(a => a.GetBySearch(null)),
                        HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get, HtmlMethod.Post },
                        Relationship = UrlRelationship.Next
                    },
                    Visits = new ResourceLink
                    {
                        Description = _configuration.GetSection("VisitsControllerDescription").Value,
                        Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null)),
                        HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get, HtmlMethod.Post },
                        Relationship = UrlRelationship.Next
                    },
                    Data = new  ResourceLink
                    {    
                        Description = _configuration.GetSection("DataControllerDescription").Value,
                        Href = _urlHelper.Action<HomeController>(a => a.Get()),
                        HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get},
                        Relationship = UrlRelationship.Next
                    },
                    Analytics = new  ResourceLink
                    {    
                        Description = _configuration.GetSection("AnalyticsControllerDescription").Value,
                        Href = _urlHelper.Action<HomeController>(a => a.Get()),
                        HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get},
                        Relationship = UrlRelationship.Next
                    }
                }
            };
            
            return Ok(navStructure);
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
            public ResourceLink Patients { get; set; }
            public ResourceLink Visits { get; set; }
            public ResourceLink Data { get; set; }
            public ResourceLink Analytics { get; set; }
        }
    }
}