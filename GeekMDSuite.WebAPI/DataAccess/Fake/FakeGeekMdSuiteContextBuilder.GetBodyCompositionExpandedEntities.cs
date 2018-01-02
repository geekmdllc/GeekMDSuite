using System.Collections.Generic;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<BodyCompositionExpandedEntity> GetBodyCompositionExpandedEntities()
            => new List<BodyCompositionExpandedEntity>()
            {
                new BodyCompositionExpandedEntity(BodyCompositionExpandedBuilder.Initialize()
                    .SetBodyFatPercentage(13)
                    .SetHeight(72)
                    .SetHips(40)
                    .SetVisceralFat(55)
                    .SetWaist(35)
                    .SetWeight(210)
                    .Build()) {VisitId = BruceWaynesVisitGuid},
                new BodyCompositionExpandedEntity(BodyCompositionExpandedBuilder.Initialize()
                    .SetBodyFatPercentage(29)
                    .SetHeight(66)
                    .SetHips(39)
                    .SetVisceralFat(105)
                    .SetWaist(29)
                    .SetWeight(135)
                    .Build()) {VisitId = XerMajestiesVisitGuid}
            };
    }
}