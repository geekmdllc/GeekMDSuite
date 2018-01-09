using System;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities
{
    public class StretchingRegimenEntity : StretchingRegimen, IVisitData<StretchingRegimen>
    {
        public int Id { get; set; }
        public Guid VisitId { get; set; }

        public StretchingRegimenEntity()
        {
            
        }

        public StretchingRegimenEntity(StretchingRegimen regimen)
        {
            MapValues(regimen);
        }

        public void MapValues(StretchingRegimen subject)
        {
            AverageSessionDuration = subject.AverageSessionDuration;
            Intensity = subject.Intensity;
            SessionsPerWeek = subject.SessionsPerWeek;
        }
    }
}
