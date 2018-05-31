using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class QuantitativeLabStub : IVisitData
    {
        public double Result { get; set; }
        public QuantitativeLabType Type { get; set; }
        public MeasurementSystem MeasurementSystem { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}