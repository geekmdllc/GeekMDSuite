using System.Collections.Generic;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<StretchingRegimenEntity> GetStretchingRegimenEntities()
        {
            return new List<StretchingRegimenEntity>
            {
                new StretchingRegimenEntity(StretchingRegimen.Build(7, 10, ExerciseIntensity.High))
                {
                    VisitGuid = BruceWaynesVisitGuid
                },
                new StretchingRegimenEntity(StretchingRegimen.Build(1, 5, ExerciseIntensity.Low))
                {
                    VisitGuid = XerMajestiesVisitGuid
                }
            };
        }
    }
}