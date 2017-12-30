using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class GripStrengthEntity : GripStrength, IVisitData<GripStrength>
    {
        public void MapValues(GripStrength subject)
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}