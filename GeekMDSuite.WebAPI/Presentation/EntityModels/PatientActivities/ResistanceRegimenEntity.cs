using System;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities
{
    public class ResistanceRegimenEntity : ResistanceRegimen, IMapProperties<ResistanceRegimen>, IVisitData
    {
        public ResistanceRegimenEntity()
        {
        }

        public ResistanceRegimenEntity(ResistanceRegimen resistanceRegimen)
        {
            MapValues(resistanceRegimen);
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }

        public void MapValues(ResistanceRegimen subject)
        {
            Features.Clear();
            Features.AddRange(subject.Features);
            SecondsRestDurationPerSet = subject.SecondsRestDurationPerSet;
            AverageSessionDuration = subject.AverageSessionDuration;
            Intensity = subject.Intensity;
            SessionsPerWeek = subject.SessionsPerWeek;
        }
    }
}