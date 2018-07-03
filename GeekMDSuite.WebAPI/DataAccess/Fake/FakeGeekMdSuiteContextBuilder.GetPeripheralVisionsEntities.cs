using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static List<PeripheralVisionEntity> GetPeripheralVisionEntities()
        {
            return new List<PeripheralVisionEntity>
            {
                new PeripheralVisionEntity(PeripheralVision.Build(90, 55)) {VisitGuid = BruceWaynesVisitGuid},
                new PeripheralVisionEntity(PeripheralVision.Build(85, 85)) {VisitGuid = XerMajestiesVisitGuid}
            };
        }
    }
}