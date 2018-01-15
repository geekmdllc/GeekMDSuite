using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class SpirometryEntity : Spirometry, IMapProperties<Spirometry>, IVisitData
    {
        public SpirometryEntity()
        {
        }

        public SpirometryEntity(Spirometry spirometry)
        {
            MapValues(spirometry);
        }

        public void MapValues(Spirometry subject)
        {
            ForcedExpiratoryFlow25To75 = subject.ForcedExpiratoryFlow25To75;
            ForcedExpiratoryTime = subject.ForcedExpiratoryTime;
            ForcedExpiratoryVolume1Second = subject.ForcedExpiratoryVolume1Second;
            ForcedVitalCapacity = subject.ForcedVitalCapacity;
            PeakExpiratoryFlow = subject.PeakExpiratoryFlow;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}