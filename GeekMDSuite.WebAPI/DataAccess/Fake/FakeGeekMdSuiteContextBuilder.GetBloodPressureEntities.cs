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
                new BloodPressureEntity(BloodPressure.Build(115, 75)),
                new BloodPressureEntity(BloodPressure.Build(115, 85)),
                new BloodPressureEntity(BloodPressure.Build(125, 85)),
                new BloodPressureEntity(BloodPressure.Build(135, 85)),
                new BloodPressureEntity(BloodPressure.Build(145, 95)),
                new BloodPressureEntity(BloodPressure.Build(165, 99)),
                new BloodPressureEntity(BloodPressure.Build(185, 101)),
                new BloodPressureEntity(BloodPressure.Build(190, 110, true)),
            };
        }
    }
}