using GeekMDSuite.WebAPI.Core.Presentation;
using Newtonsoft.Json;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class ResourceLink
    {
        public string Description { get; set; }
        public string Href { get; set; }

        [JsonIgnore]
        public UrlRelationship Relationship { get; set; }

        public string Rel => Relationship.ToString();

        [JsonIgnore]
        public HtmlMethod HtmlMethod { get; set; }

        public string Method => HtmlMethod.ToString();
    }
}