using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using Microsoft.AspNetCore.Mvc.Routing;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters
{
    public class VisitDataSearchFilter
    {
        public Guid? PatientGuid { get; set; }
        public string MedicalRecordNumber { get; set; }
        public string Name { get; set; }
        public int? VisitMonth { get; set; }
        public int? VisitDay { get; set; }
        public int? VisitYear { get; set; }
        public SortOrder? SortOrder { get; set; }
    }
}