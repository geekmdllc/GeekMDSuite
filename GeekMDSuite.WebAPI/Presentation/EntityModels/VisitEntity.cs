using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VisitEntity : IVisitData<VisitEntity>
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }
        public Guid PatientGuid { get; set; }
        public DateTime Date { get; set; }

        public VisitEntity()
        {
            Visit = Guid.Empty;
        }

        public VisitEntity(Guid patientGuid) : this()
        {
            PatientGuid = patientGuid;
        }
        
        public void MapValues(VisitEntity subject)
        {
            PatientGuid = subject.PatientGuid;
            Date = subject.Date;
        }
    }
}