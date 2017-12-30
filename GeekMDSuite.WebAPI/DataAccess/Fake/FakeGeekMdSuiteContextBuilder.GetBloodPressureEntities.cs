using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<BloodPressureEntity> GetBloodPressureEntities()
        {
            return new List<BloodPressureEntity>()
            {
                new BloodPressureEntity(BloodPressure.Build(115, 75)) { Visit = XerMajestiesVisitGuid },
                new BloodPressureEntity(BloodPressure.Build(190, 110, true)) { Visit = BruceWaynesVisitGuid },
            };
        }
    }
}