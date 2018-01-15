using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class GripStrengthStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public GripStrengthStub()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
    }
}