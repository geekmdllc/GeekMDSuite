using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class GripStrengthEntity : GripStrength, IMapProperties<GripStrength>, IVisitData
    {
        public GripStrengthEntity()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }

        public GripStrengthEntity(GripStrength gripStrength) : this()
        {
            MapValues(gripStrength);
        }

        public void MapValues(GripStrength subject)
        {
            Left.Pounds = subject.Left.Pounds;
            Right.Pounds = subject.Right.Pounds;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}