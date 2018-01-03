using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.PatientActivities;

namespace GeekMDSuite.Analytics.Classification.PatientActivities
{
    public class CardiovascularRegimenClassification : ExerciseRegimenClassification
    {
        public CardiovascularRegimenClassification(ExerciseRegimen regimen) : base(regimen)
        {
            if (regimen == null) throw new ArgumentNullException(nameof(regimen));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}