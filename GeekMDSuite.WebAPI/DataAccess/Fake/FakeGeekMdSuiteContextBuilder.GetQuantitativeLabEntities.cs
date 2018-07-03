using System.Collections.Generic;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static IEnumerable<QuantitativeLabEntity> GetQuantitativeLabEntities()
        {
            return new List<QuantitativeLabEntity>
            {
                new QuantitativeLabEntity
                {
                    VisitGuid = BruceWaynesVisitGuid,
                    MeasurementSystem = MeasurementSystem.TraditionalUs,
                    Result = 450,
                    Type = QuantitativeLabType.TestosteroneTotalSerum
                },
                new QuantitativeLabEntity
                {
                    VisitGuid = XerMajestiesVisitGuid,
                    MeasurementSystem = MeasurementSystem.TraditionalUs,
                    Result = 35,
                    Type = QuantitativeLabType.TestosteroneTotalSerum
                }
            };
        }
    }
}