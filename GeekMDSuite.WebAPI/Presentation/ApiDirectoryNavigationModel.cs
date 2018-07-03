namespace GeekMDSuite.WebAPI.Presentation
{
    public class ApiDirectoryNavigationModel<TLinks> where TLinks : class, new()
    {
        public ApiDirectoryNavigationModel()
        {
            Links = new TLinks();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public TLinks Links { get; set; }
    }
}