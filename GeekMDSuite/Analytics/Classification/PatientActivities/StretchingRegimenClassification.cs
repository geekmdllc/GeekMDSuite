using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

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