using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<TreadmillExerciseStressTestEntity> GetTreadmillExerciseStressTestEntities()
        {
            return new List<TreadmillExerciseStressTestEntity>
            {
                new TreadmillExerciseStressTestEntity(TreadmillExerciseStressTestBuilder.Initialize()
                    .SetMaximumBloodPressure(195, 93)
                    .SetMaximumHeartRate(172)
                    .SetProtocol()
                    .SetResult(TmstResult.Normal)
                    .SetSupineBloodPressure(115, 69)
                    .SetSupineHeartRate(55)
                    .SetTime(18, 33)
                    .Build()) {Guid = BruceWaynesVisitGuid},
                new TreadmillExerciseStressTestEntity(TreadmillExerciseStressTestBuilder.Initialize()
                    .SetMaximumBloodPressure(220, 110)
                    .SetMaximumHeartRate(155)
                    .SetProtocol()
                    .SetResult(TmstResult.Ischemia)
                    .SetSupineBloodPressure(145, 79)
                    .SetSupineHeartRate(78)
                    .SetTime(7, 33)
                    .Build()) {Guid = XerMajestiesVisitGuid}
            };
        }
    }
}