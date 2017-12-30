using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<CentralBloodPressureEntity> GetCentralBloodPressureEntities()
        {
            var cbpe = new CentralBloodPressureEntity(CentralBloodPressureBuilder.Initialize()
                .SetAugmentedIndex(33)
                .SetAugmentedPressure(8)
                .SetCentralSystolicPressure(132)
                .SetPulsePressure(44)
                .SetPulseWaveVelocity(7.9)
                .SetReferenceAge(44)
                .Build());
            return new List<CentralBloodPressureEntity>()
            {
                cbpe,
                cbpe,
                cbpe
            };
        }
    }
}