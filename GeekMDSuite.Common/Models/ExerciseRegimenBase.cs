namespace GeekMDSuite.Common.Models
{
    public abstract class ExerciseRegimenBase : IExerciseRegimen
    {
        public ExerciseRegimenBase (double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }
        public double SessionsPerWeek { get; set; }
        public double AverageSessionDuration { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public abstract ExerciseDurationGoals Goals { get; protected set; }
        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;
    }
}