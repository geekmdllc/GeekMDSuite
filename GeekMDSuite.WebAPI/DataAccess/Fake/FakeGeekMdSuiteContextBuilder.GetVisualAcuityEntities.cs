using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<VisualAcuityEntity> GetVisualAcuityEntities()
        {
            return new List<VisualAcuityEntity>()
            {
                new VisualAcuityEntity(VisualAcuity.Build(20, 20, 20)) {Visit = BruceWaynesVisitGuid},
                new VisualAcuityEntity(VisualAcuity.Build(30, 40, 40)) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}