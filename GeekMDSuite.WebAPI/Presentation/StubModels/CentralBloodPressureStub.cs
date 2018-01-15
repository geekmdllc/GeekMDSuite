using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class CentralBloodPressureStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double SystolicPressure { get; set; }
        public double PulsePressure { get; set; }
        public double AugmentedPressure { get; set; }
        public double AugmentedIndex { get; set; }
        public double ReferenceAge { get; set; }
        public double PulseWaveVelocity { get; set; }
    }
}