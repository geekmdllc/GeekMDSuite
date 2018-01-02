using System.Collections.Generic;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<GripStrengthEntity> GetGripStrengthEntities()
        {
            return new List<GripStrengthEntity>()
            {
                new GripStrengthEntity(GripStrength.Build(190, 185)) {Visit = BruceWaynesVisitGuid},
                new GripStrengthEntity(GripStrength.Build(105, 105)) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}