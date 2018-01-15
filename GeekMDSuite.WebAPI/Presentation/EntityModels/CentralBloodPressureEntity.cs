using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class CentralBloodPressureEntity : CentralBloodPressure, IMapProperties<CentralBloodPressure>, IVisitData
    {
        public CentralBloodPressureEntity()
        {
            Guid = Guid.Empty;
        }

        public CentralBloodPressureEntity(CentralBloodPressure centralBloodPressure) : this()
        {
            MapValues(centralBloodPressure);
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }

        public void MapValues(CentralBloodPressure subject)
        {
            AugmentedIndex = subject.AugmentedIndex;
            AugmentedPressure = subject.AugmentedPressure;
            PulsePressure = subject.PulsePressure;
            PulseWaveVelocity = subject.PulseWaveVelocity;
            ReferenceAge = subject.ReferenceAge;
            SystolicPressure = subject.SystolicPressure;
        }
    }
}