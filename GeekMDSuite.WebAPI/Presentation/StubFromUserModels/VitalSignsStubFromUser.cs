using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VitalSignsStubFromUser : IVisitData
    {
        public VitalSignsStubFromUser()
        {
            BloodPressure = new BloodPressure();
            Temperature = new Temperature();
        }

        public BloodPressure BloodPressure { get; set; }
        public int OxygenSaturation { get; set; }
        public int PulseRate { get; set; }
        public Temperature Temperature { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}