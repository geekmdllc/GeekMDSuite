namespace GeekMDSuite.Services
{
    public static class GetExerciseGoalValues
    {
        public static ExerciseDurationGoals TotalWeeklyDuration(ExerciseClassifications exercise)
        {
            if(exercise == ExerciseClassifications.Cardiovascular)
                return new ExerciseDurationGoals{HighIntensity = 75, ModerateIntensity = 150};
            return exercise == ExerciseClassifications.Resistance 
                ? new ExerciseDurationGoals{HighIntensity = 90, ModerateIntensity = 120} 
                : new ExerciseDurationGoals{HighIntensity = 20, ModerateIntensity = 30};
        }

        public static Interval<int> ResistanceRestInterval(int upper = 120, int lower = 30)
        {
            return new Interval<int>(lower,upper);
        }
    }
}