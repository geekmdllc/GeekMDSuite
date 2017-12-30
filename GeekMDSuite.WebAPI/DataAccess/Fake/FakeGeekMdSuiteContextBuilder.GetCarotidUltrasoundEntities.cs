using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<CarotidUltrasoundEntity> GetCarotidUltrasoundEntities()
        {
            var left = CarotidUltrasoundResultBuilder.Initialize()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                .SetIntimaMediaThickeness(0.655)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .Build();
            var right = CarotidUltrasoundResultBuilder.Initialize()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                .SetIntimaMediaThickeness(0.655)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .Build();
            var cu = CarotidUltrasound.Build(left, right);

            var left2 = CarotidUltrasoundResultBuilder.Initialize()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                .SetIntimaMediaThickeness(0.655)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .Build();
            var right2 = CarotidUltrasoundResultBuilder.Initialize()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.CriticalSignificant)
                .SetIntimaMediaThickeness(0.655)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .Build();
            var cu2 = CarotidUltrasound.Build(left2, right2);

            return new List<CarotidUltrasoundEntity>()
            {
                new CarotidUltrasoundEntity(cu) { Visit = XerMajestiesVisitGuid },
                new CarotidUltrasoundEntity(cu2) { Visit = BruceWaynesVisitGuid }
            };
        }
    }
}