﻿using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.MeasurementUnits;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class VitalSignsStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public BloodPressure BloodPressure { get; set; }
        public int OxygenSaturation { get; set; }
        public int PulseRate { get; set; }
        public Temperature Temperature { get; set; }

        public VitalSignsStub()
        {
            BloodPressure = new BloodPressure();
            Temperature = new Temperature();
        }
    }
}