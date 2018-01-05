using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<OcularPressureEntity> GetOcularPressureEntities()
        {
            return new List<OcularPressureEntity>()
            {
                new OcularPressureEntity(OcularPressure.Build(20, 30)) {VisitId = BruceWaynesVisitGuid },
                new OcularPressureEntity(OcularPressure.Build(15, 15)) {VisitId = XerMajestiesVisitGuid }
            };
        }
    }
}