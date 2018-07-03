using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class QuantitativeLabEntity : QuantitativeLab, IMapProperties<QuantitativeLab>, IVisitData
    {
        public void MapValues(QuantitativeLab subject)
        {
            MeasurementSystem = subject.MeasurementSystem;
            Result = subject.Result;
            Type = subject.Type;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}