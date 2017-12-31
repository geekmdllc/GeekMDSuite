using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class OcularPressureEntity : OcularPressure, IVisitData<OcularPressure>
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }

        public OcularPressureEntity() {}

        public OcularPressureEntity(OcularPressure ocularPressure)
        {
            MapValues(ocularPressure);
        }
        
        public void MapValues(OcularPressure subject)
        {
            Left = subject.Left;
            Right = subject.Right;
        }
    }
}