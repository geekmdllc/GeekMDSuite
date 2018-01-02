using System;
using GeekMDSuite.Core.PatientActivities;
using GeekMDSuite.Core.Services.Repositories;

namespace GeekMDSuite.Core.Analytics.Classification.PatientActivities
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