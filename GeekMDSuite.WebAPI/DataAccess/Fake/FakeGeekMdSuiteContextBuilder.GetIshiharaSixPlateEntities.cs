using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        public static List<IshiharaSixPlateEntity> GetIshiharaSixPlateEntities()
        {
            var set1 = IshiharaSixPlateScreenBuilder.Initialize()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .Build();

            var set2 = IshiharaSixPlateScreenBuilder.Initialize()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate6(IshiharaAnswerResult.NormalVision)
                .Build();

            return new List<IshiharaSixPlateEntity>
            {
                new IshiharaSixPlateEntity(set1) {VisitGuid = BruceWaynesVisitGuid},
                new IshiharaSixPlateEntity(set2) {VisitGuid = XerMajestyGuid}
            };
        }
    }
}