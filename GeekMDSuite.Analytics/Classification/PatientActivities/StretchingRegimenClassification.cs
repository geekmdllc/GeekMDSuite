using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class StretchingRegimenClassification : ExerciseRegimenClassification
    {
        public StretchingRegimenClassification(ExerciseRegimen regimen) : base(regimen)
        {
            if (regimen == null) throw new ArgumentNullException(nameof(regimen));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Stretching);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}