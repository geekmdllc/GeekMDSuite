using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class OccularPressureEntity : OccularPressure, IVisitData<OccularPressure>
    {
        public OccularPressureEntity()
        {
        }

        public OccularPressureEntity(OccularPressure occularPressure)
        {
            MapValues(occularPressure);
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }

        public void MapValues(OccularPressure subject)
        {
            Left = subject.Left;
            Right = subject.Right;
        }
    }
}