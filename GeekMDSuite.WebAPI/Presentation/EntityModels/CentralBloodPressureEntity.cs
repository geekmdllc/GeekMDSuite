using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class CentralBloodPressureEntity : CentralBloodPressure, IMapProperties<CentralBloodPressure>, IVisitData
    {
        public CentralBloodPressureEntity()
        {
            VisitGuid = Guid.Empty;
        }

        public CentralBloodPressureEntity(CentralBloodPressure centralBloodPressure) : this()
        {
            MapValues(centralBloodPressure);
        }

        public void MapValues(CentralBloodPressure subject)
        {
            AugmentedIndex = subject.AugmentedIndex;
            AugmentedPressure = subject.AugmentedPressure;
            PulsePressure = subject.PulsePressure;
            PulseWaveVelocity = subject.PulseWaveVelocity;
            ReferenceAge = subject.ReferenceAge;
            SystolicPressure = subject.SystolicPressure;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}