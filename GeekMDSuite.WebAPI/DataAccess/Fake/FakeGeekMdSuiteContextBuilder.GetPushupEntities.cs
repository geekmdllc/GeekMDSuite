using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<PushupsEntity> GetPushupsEntities()
        {
            return new List<PushupsEntity>()
            {
                new PushupsEntity(Pushups.Build(143)) {Visit = BruceWaynesVisitGuid},
                new PushupsEntity(Pushups.Build(63)) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}