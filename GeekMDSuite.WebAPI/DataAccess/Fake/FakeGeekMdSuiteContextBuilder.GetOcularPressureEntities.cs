using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<OccularPressureEntity> GetOcularPressureEntities()
        {
            return new List<OccularPressureEntity>
            {
                new OccularPressureEntity(OccularPressure.Build(20, 30)) {Guid = BruceWaynesVisitGuid},
                new OccularPressureEntity(OccularPressure.Build(15, 15)) {Guid = XerMajestiesVisitGuid}
            };
        }
    }
}