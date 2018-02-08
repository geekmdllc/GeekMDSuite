using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class GripStrengthStub : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public GripStrengthStub()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
    }
}