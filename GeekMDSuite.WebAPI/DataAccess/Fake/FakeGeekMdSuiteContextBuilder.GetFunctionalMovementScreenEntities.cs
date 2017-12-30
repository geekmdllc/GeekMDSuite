using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<FunctionalMovementScreenEntity> GetFunctionalMovementScreenEntities()
        {
            return new List<FunctionalMovementScreenEntity>()
            {
                new FunctionalMovementScreenEntity(FunctionalMovementScreenBuilder.Initialize()
                    .SetActiveStraightLegRaise(2, 3)
                    .SetDeepSquat(3)
                    .SetHurdleStep(2, 3)
                    .SetInlineLunge(2, 3)
                    .SetRotaryStability(2, 2, false)
                    .SetShoulderMobility(2, true, 1, true)
                    .SetTrunkStabilityPuhsup(2, false)
                    .Build()) { Visit = XerMajestiesVisitGuid },
                new FunctionalMovementScreenEntity(FunctionalMovementScreenBuilder.Initialize()
                    .SetActiveStraightLegRaise(3, 3)
                    .SetDeepSquat(3)
                    .SetHurdleStep(3, 3)
                    .SetInlineLunge(3, 3)
                    .SetRotaryStability(3, 3, false)
                    .SetShoulderMobility(3, false, 3, false)
                    .SetTrunkStabilityPuhsup(3, false)
                    .Build()) { Visit = BruceWaynesVisitGuid }
            };
        }
    }
}