using System.Collections.Generic;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static IEnumerable<QualitativeLabEntity> GetQualitativeLabEntities()
        {
            return new List<QualitativeLabEntity>
            {
                new QualitativeLabEntity
                {
                    VisitGuid = BruceWaynesGuid,
                    Result = QualitativeLabResult.Negative,
                    Type = QualitativeLabType.Hiv
                },
                new QualitativeLabEntity
                {
                    VisitGuid = XerMajestiesVisitGuid,
                    Result = QualitativeLabResult.Positive,
                    Type = QualitativeLabType.Hiv
                }
            };
        }
    }
}