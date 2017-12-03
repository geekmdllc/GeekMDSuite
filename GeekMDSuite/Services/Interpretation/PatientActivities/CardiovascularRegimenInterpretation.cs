using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Fitness;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class CardiovascularRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public CardiovascularRegimenInterpretation(IExerciseRegimenParameters parameters) : base(parameters)
        {
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassification.Cardiovascular);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}