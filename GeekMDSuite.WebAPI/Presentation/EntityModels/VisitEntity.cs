using System;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VisitEntity : IVisitData<VisitEntity>
    {
        public VisitEntity()
        {
            Guid = Guid.Empty;
        }

        public VisitEntity(VisitEntity visitEntity) : this()
        {
            MapValues(visitEntity);
        }

        public DateTime Date { get; set; }
        public Guid PatientGuid { get; set; }
        public VisitStatus Status { get; set; }

        public int Id { get; set; }
        public Guid Guid { get; set; }

        public virtual void MapValues(VisitEntity subject)
        {
            PatientGuid = subject.PatientGuid;
            Date = subject.Date;
            Status = subject.Status;
        }
    }
}