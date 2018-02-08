using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class GripStrengthStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public GripStrengthStubFromUser()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
    }
}