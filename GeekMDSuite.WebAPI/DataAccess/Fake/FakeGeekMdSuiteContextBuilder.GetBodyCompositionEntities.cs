using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<BodyCompositionEntity> GetBodyCompositionEntities()
        {
            return new List<BodyCompositionEntity>
            {
                new BodyCompositionEntity(BodyCompositionBuilder.Initialize()
                    .SetHeight(72)
                    .SetHips(40)
                    .SetWaist(34)
                    .SetWeight(210)
                    .Build()) {VisitGuid = BruceWaynesVisitGuid},
                new BodyCompositionEntity(BodyCompositionBuilder.Initialize()
                    .SetHeight(66)
                    .SetHips(39)
                    .SetWaist(23)
                    .SetWeight(132)
                    .Build()) {VisitGuid = XerMajestiesVisitGuid}
            };
        }
    }
}