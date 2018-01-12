using System;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceModels
{
    public class VisitResourceModel : VisitEntity
    {
        public PatientEntity Patient { get; set; }

        public VisitResourceModel()
        {
            Patient = new PatientEntity();
        }

        public VisitResourceModel(VisitEntity visitEntity, PatientEntity patientEntity) : this()
        {
            MapValues(visitEntity);
            Patient = patientEntity;
        }

        public override void MapValues(VisitEntity subject)
        {
            base.MapValues(subject);
            Id = subject.Id;
            VisitId = subject.VisitId;
        }
    }
}