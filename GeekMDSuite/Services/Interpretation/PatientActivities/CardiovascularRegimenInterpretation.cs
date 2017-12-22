using System;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class CardiovascularRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public CardiovascularRegimenInterpretation(IExerciseRegimenParameters parameters) : base(parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Goals = ExerciseRegimenGoalsRepository.GetTotalWeeklyDurationGoals(ExerciseClassification.Cardiovascular);
        }

        public override ExerciseDurationGoals Goals { get; }
        public override InterpretationText Interpretation => throw new NotImplementedException();
    }
}