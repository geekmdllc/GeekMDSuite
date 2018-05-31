using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class QualitativeLabEntity : QualitativeLab, IMapProperties<QualitativeLab>, IVisitData
    {
        public void MapValues(QualitativeLab subject)
        {
            Result = subject.Result;
            Type = subject.Type;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}