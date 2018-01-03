using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class StretchingRegimenClassification : ExerciseRegimenClassification
    {
        public StretchingRegimenClassification(IExerciseRegimenParameters parameters) : base(parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Stretching);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}