using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<CentralBloodPressureEntity> GetCentralBloodPressureEntities()
        {
            return new List<CentralBloodPressureEntity>()
            {
                new CentralBloodPressureEntity(CentralBloodPressureBuilder.Initialize()
                    .SetAugmentedIndex(33)
                    .SetAugmentedPressure(8)
                    .SetCentralSystolicPressure(132)
                    .SetPulsePressure(44)
                    .SetPulseWaveVelocity(7.9)
                    .SetReferenceAge(44)
                    .Build()) { Visit = XerMajestiesVisitGuid },
                new CentralBloodPressureEntity(CentralBloodPressureBuilder.Initialize()
                    .SetAugmentedIndex(31)
                    .SetAugmentedPressure(11)
                    .SetCentralSystolicPressure(121)
                    .SetPulsePressure(32)
                    .SetPulseWaveVelocity(9.9)
                    .SetReferenceAge(56)
                    .Build()) { Visit = BruceWaynesVisitGuid }
            };
        }
    }
}