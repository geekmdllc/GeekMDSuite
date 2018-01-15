using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class GripStrengthStubFromUser : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public GripStrengthStubFromUser()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
    }
}