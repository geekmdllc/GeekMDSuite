using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class CardiovascularRegimenClassification : ExerciseRegimenClassification
    {
        public CardiovascularRegimenClassification(IExerciseRegimenParameters parameters) : base(parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}