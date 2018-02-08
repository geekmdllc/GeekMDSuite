namespace GeekMDSuite.WebAPI.Presentation
{
    public class ApiDirectoryNavigationModel<TLinks> where TLinks: class, new()
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TLinks Links { get; set; }

        public ApiDirectoryNavigationModel()
        {
            Links = new TLinks();
        }
            
    }
}