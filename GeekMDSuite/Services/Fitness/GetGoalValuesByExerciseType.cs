using GeekMDSuite.PatientActivities;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Fitness
{
    internal static class GetGoalValuesByExerciseType
    {
        internal static ExerciseDurationGoals TotalWeeklyDuration(ExerciseClassification exercise)
        {
            if(exercise == ExerciseClassification.Cardiovascular)
                return new ExerciseDurationGoals(150,75);
            return exercise == ExerciseClassification.Resistance
                ? new ExerciseDurationGoals(120, 90)
                : new ExerciseDurationGoals(30, 20);
        }

        internal static Interval<int> ResistanceRestInterval(int upper = 120, int lower = 30)
        {
            return new Interval<int>(lower,upper);
        }
    }
}