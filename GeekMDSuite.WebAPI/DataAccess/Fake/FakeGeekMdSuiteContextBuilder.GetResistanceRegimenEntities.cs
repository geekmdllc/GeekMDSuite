using System.Collections.Generic;
using GeekMDSuite.Core.Builders.PatientActivities;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static IEnumerable<ResistanceRegimenEntity> GetResistanceRegimenEntities()
        {
            return new List<ResistanceRegimenEntity>
            {
                new ResistanceRegimenEntity(ResistanceRegimenBuilder.Initialize()
                    .ConfirmLowerBodyTrained()
                    .ConfirmPullingMovementsPerformed()
                    .ConfirmRepetitionsToNearFailure()
                    .ConfirmUpperBodyTrained()
                    .SetSecondsRestDurationPerSet(150)
                    .SetAverageSessionDuration(90)
                    .SetIntensity(ExerciseIntensity.High)
                    .SetSessionsPerWeek(4)
                    .Build()) {VisitGuid = BruceWaynesVisitGuid},
                new ResistanceRegimenEntity(ResistanceRegimenBuilder.Initialize()
                    .ConfirmLowerBodyTrained()
                    .ConfirmPullingMovementsPerformed()
                    .ConfirmPushingMovementsPerformed()
                    .ConfirmRepetitionsToNearFailure()
                    .ConfirmUpperBodyTrained()
                    .SetSecondsRestDurationPerSet(76)
                    .SetAverageSessionDuration(90)
                    .SetIntensity(ExerciseIntensity.High)
                    .SetSessionsPerWeek(4)
                    .Build()) {VisitGuid = XerMajestiesVisitGuid}
            };
        }
    }
}