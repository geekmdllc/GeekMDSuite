using System;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class SpirometryStubFromUser : IStub

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