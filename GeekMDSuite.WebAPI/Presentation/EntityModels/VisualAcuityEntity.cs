using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VisualAcuityEntity : VisualAcuity, IVisitData<VisualAcuity>
    {
        public VisualAcuityEntity()
        {
            
        }

        public VisualAcuityEntity(VisualAcuity visualAcuity)
        {
            MapValues(visualAcuity);
        }
        public void MapValues(VisualAcuity subject)
        {
            Both = subject.Both;
            Distance = subject.Distance;
            Near = subject.Near;
        }

        public int Id { get; set; }
        public Guid VisitId { get; set; }
    }
}