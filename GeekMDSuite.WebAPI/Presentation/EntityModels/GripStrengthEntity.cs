using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class GripStrengthEntity : GripStrength, IVisitData<GripStrength>
    {
        public void MapValues(GripStrength subject)
        {
            Left.Pounds = subject.Left.Pounds;
            Right.Pounds = subject.Right.Pounds;
        }

        public GripStrengthEntity()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }

        public GripStrengthEntity(GripStrength gripStrength) : this()
        {
            MapValues(gripStrength);
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}