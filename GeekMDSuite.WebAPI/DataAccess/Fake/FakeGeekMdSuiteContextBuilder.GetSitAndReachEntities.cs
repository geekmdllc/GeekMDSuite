using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static List<SitAndReachEntity> GetSitAndReachEntities()
        {
            return new List<SitAndReachEntity>()
            {
                new SitAndReachEntity(SitAndReach.Build(12)) {Visit = BruceWaynesVisitGuid},
                new SitAndReachEntity(SitAndReach.Build(25)) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}