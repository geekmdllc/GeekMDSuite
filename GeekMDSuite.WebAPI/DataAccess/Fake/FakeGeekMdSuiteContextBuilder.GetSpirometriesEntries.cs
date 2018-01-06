using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<SpirometryEntity> GetSpirometryEntities()
        {
            return new List<SpirometryEntity>()
            {
                new SpirometryEntity((SpirometryBuilder.Initialize()
                    .SetForcedExpiratoryFlow25To75(5.5)
                    .SetForcedExpiratoryTime(6.5)
                    .SetForcedExpiratoryVolume1Second(4.3)
                    .SetForcedVitalCapacity(6.7)
                    .SetPeakExpiratoryFlow(9.4)
                    .Build())) {VisitId = BruceWaynesVisitGuid},
                new SpirometryEntity((SpirometryBuilder.Initialize()
                    .SetForcedExpiratoryFlow25To75(4.5)
                    .SetForcedExpiratoryTime(5.5)
                    .SetForcedExpiratoryVolume1Second(3.3)
                    .SetForcedVitalCapacity(5.7)
                    .SetPeakExpiratoryFlow(8.4)
                    .Build())) {VisitId = XerMajestiesVisitGuid}
            };
        }
    }
}