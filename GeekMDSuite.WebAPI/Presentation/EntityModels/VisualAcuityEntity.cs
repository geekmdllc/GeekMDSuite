using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VisualAcuityEntity : VisualAcuity, IMapProperties<VisualAcuity>, IVisitData
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
        public Guid VisitGuid { get; set; }
    }
}