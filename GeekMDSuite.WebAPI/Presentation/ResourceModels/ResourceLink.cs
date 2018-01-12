using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class ResourceLink
    {
        public string Href { get; set; }
        public UrlRelationship Rel { get; set; }
    }
}