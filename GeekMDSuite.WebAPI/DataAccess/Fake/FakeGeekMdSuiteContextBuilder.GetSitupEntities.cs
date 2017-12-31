using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<SitupsEntity> GetSitupEntities()
        {
            return new List<SitupsEntity>()
            {
                new SitupsEntity(Situps.Build(190)) {Visit = BruceWaynesVisitGuid},
                new SitupsEntity(Situps.Build(23)) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}