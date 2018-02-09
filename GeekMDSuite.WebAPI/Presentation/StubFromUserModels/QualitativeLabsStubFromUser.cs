using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class QualitativeLabsStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public QualitativeLabType Type { get; set; }
        public QualitativeLabResult Result { get; set; }
        public MeasurementSystem MeasurementSystem { get; set; }
    }
}