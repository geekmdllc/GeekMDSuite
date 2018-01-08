using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class StretchingRegimenClassification : ExerciseRegimenClassification
    {
        public StretchingRegimenClassification(StretchingRegimen regimen) : base(regimen)
        {
            if (regimen == null) throw new ArgumentNullException(nameof(regimen));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Stretching);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}