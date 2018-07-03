using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class SitupsEntity : Situps, IMapProperties<Situps>, IVisitData
    {
        public SitupsEntity()
        {
        }

        public SitupsEntity(Situps situps) : this()
        {
            MapValues(situps);
        }

        public void MapValues(Situps subject)
        {
            Value = subject.Value;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}