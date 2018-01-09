using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VisitEntity : IVisitData<VisitEntity>
    {
        public VisitEntity()
        {
            VisitId = Guid.Empty;
        }

        public VisitEntity(VisitEntity visitEntity) : this()
        {
            MapValues(visitEntity);
        }

        public Guid PatientGuid { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public Guid VisitId { get; set; }

        public void MapValues(VisitEntity subject)
        {
            PatientGuid = subject.PatientGuid;
            Date = subject.Date;
        }
    }
}