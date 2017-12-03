using GeekMDSuite.PatientActivities;
using GeekMDSuite.Services.Fitness;

namespace GeekMDSuite.Services.Interpretation.PatientActivities
{
    public class StretchingRegimenInterpretation : ExerciseRegimenInterpretation
    {
        public StretchingRegimenInterpretation(IExerciseRegimenParameters parameters) : base(parameters)
        {
            Goals = GetGoalValuesByExerciseType.TotalWeeklyDuration(ExerciseClassification.Stretching);
        }

        public override ExerciseDurationGoals Goals { get; }
    }
}