using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class SpirometryStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public double ForcedExpiratoryVolume1Second { get; set; }
        public double ForcedVitalCapacity { get; set; }
        public double PeakExpiratoryFlow { get; set; }
        public double ForcedExpiratoryFlow25To75 { get; set; }
        public double ForcedExpiratoryTime { get; set; }
        public double ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio =>
            ForcedExpiratoryVolume1Second / ForcedVitalCapacity;
    }
}