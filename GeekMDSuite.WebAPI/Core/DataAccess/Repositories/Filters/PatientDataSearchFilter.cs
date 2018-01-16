namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters
{
    public class PatientDataSearchFilter
    {
        public string MedicalRecordNumber { get; set; }
        public string Name { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public int? BirthYear { get; set; }
        public SortOrder? SortOrder { get; set; }
    }
}