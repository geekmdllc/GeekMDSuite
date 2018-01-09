using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class OcularPressureEntity : OcularPressure, IVisitData<OcularPressure>
    {
        public OcularPressureEntity()
        {
        }

        public OcularPressureEntity(OcularPressure ocularPressure)
        {
            MapValues(ocularPressure);
        }

        public int Id { get; set; }
        public Guid VisitId { get; set; }

        public void MapValues(OcularPressure subject)
        {
            Left = subject.Left;
            Right = subject.Right;
        }
    }
}