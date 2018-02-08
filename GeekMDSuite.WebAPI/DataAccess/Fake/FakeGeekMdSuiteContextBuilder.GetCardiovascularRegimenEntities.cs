using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<CardiovascularRegimenEntity> GetCardiovascularRegimenEntities()
        {
            return new List<CardiovascularRegimenEntity>
            {
                new CardiovascularRegimenEntity(CardiovascularRegimen.Build(6, 60, ExerciseIntensity.High))
                {
                    VisitGuid = BruceWaynesVisitGuid
                },
                new CardiovascularRegimenEntity(CardiovascularRegimen.Build(0, 0, ExerciseIntensity.None))
                {
                    VisitGuid = XerMajestiesVisitGuid
                }
            };
        }
    }
}