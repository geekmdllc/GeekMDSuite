using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class OccularPressureEntity : OccularPressure, IMapProperties<OccularPressure>, IVisitData
    {
        public OccularPressureEntity()
        {
        }

        public OccularPressureEntity(OccularPressure occularPressure)
        {
            MapValues(occularPressure);
        }

        public void MapValues(OccularPressure subject)
        {
            Left = subject.Left;
            Right = subject.Right;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}