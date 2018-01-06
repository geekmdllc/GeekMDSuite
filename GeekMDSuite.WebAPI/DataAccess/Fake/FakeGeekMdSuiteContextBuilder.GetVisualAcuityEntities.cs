using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<VisualAcuityEntity> GetVisualAcuityEntities()
        {
            return new List<VisualAcuityEntity>
            {
                new VisualAcuityEntity(VisualAcuity.Build(20, 20, 20)) {VisitId = BruceWaynesVisitGuid},
                new VisualAcuityEntity(VisualAcuity.Build(30, 40, 40)) {VisitId = XerMajestiesVisitGuid}
            };
        }
    }
}