using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class SitupsEntity : Situps, IVisitData<Situps>
    {
        public void MapValues(Situps subject) => Value = subject.Value;

        public SitupsEntity()
        {
            
        }

        public SitupsEntity( Situps situps) : this()
        {
            MapValues(situps);
        }
        
        public int Id { get; set; }
        public Guid VisitId { get; set; }
    }
}