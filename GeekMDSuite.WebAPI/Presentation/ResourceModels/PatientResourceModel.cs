using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class PatientResourceModel : PatientEntity
    {
        public IEnumerable<VisitEntity> Visits { get; set; }
        public IEnumerable<ResourceLink> Links { get; set; }

        public PatientResourceModel()
        {
            Visits = new List<VisitResourceModel>();
            Links = new List<ResourceLink>
            {
                new ResourceLink { Rel = UrlRelationship.Self, Href = "http://www.gotcha.com/stuff"}
            };
        }

        public PatientResourceModel(PatientEntity patient, IEnumerable<VisitEntity> visits) : this()
        {
            MapValues(patient);
            Visits = visits;
        }

        public void MapValues(PatientEntity subject)
        {
            base.MapValues(subject);
            Id = subject.Id;
            Guid = subject.Guid;
        }
    }
}