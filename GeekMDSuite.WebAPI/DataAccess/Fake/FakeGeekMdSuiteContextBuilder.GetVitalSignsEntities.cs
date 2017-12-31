using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<VitalSignsEntity> GetVitalSignsEntities()
        {
            return new List<VitalSignsEntity>()
            {
                new VitalSignsEntity(VitalSignsBuilder.Initialize()
                    .SetBloodPressure(115, 65, false)
                    .SetOxygenSaturation(98)
                    .SetPulseRate(59)
                    .SetTemperature(98.1)
                    .Build()) {Visit = BruceWaynesVisitGuid},
                new VitalSignsEntity(VitalSignsBuilder.Initialize()
                    .SetBloodPressure(144, 156, false)
                    .SetOxygenSaturation(96)
                    .SetPulseRate(88)
                    .SetTemperature(99.9)
                    .Build()) {Visit = XerMajestiesVisitGuid}
            };
        }
    }
}