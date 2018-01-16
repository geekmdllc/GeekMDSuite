using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VitalSignsStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public BloodPressure BloodPressure { get; set; }
        public int OxygenSaturation { get; set; }
        public int PulseRate { get; set; }
        public Temperature Temperature { get; set; }

        public VitalSignsStubFromUser()
        {
            BloodPressure = new BloodPressure();
            Temperature = new Temperature();
        }
    }
}