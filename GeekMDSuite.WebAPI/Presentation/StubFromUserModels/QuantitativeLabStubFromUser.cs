﻿using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class QuantitativeLabStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public double Result { get; set; }
        public QuantitativeLabType Type { get; set; }
        public MeasurementSystem MeasurementSystem { get; set; }
    }
}