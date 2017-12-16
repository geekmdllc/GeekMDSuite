namespace GeekMDSuite.PatientActivities
{
    public class ExerciseRegimenParameters : IExerciseRegimenParameters
    {
        private ExerciseRegimenParameters(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }

        public double SessionsPerWeek { get; }

        public double AverageSessionDuration { get; }

        public ExerciseIntensity Intensity { get; }

        public static ExerciseRegimenParameters Build(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity) => new ExerciseRegimenParameters(sessionsPerWeek, averageSessionDuration, intensity);
    }
}