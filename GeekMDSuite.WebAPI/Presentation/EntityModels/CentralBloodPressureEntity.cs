using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class CentralBloodPressureEntity : CentralBloodPressure, IVisitData<CentralBloodPressure>
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }
        
        public void MapValues(CentralBloodPressure subject)
        {
            AugmentedIndex = subject.AugmentedIndex;
            AugmentedPressure = subject.AugmentedPressure;
            PulsePressure = subject.PulsePressure;
            PulseWaveVelocity = subject.PulseWaveVelocity;
            ReferenceAge = subject.ReferenceAge;
            SystolicPressure = subject.SystolicPressure;
        }

        public CentralBloodPressureEntity()
        {
            
        }

        public CentralBloodPressureEntity(CentralBloodPressure centralBloodPressure)
        {
            MapValues(centralBloodPressure);
        }
    }
}