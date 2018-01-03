namespace GeekMDSuite.Core.PatientActivities
{
    public class ExerciseRegimenParameters 
    {
        private ExerciseRegimenParameters(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }

        public double SessionsPerWeek { get; set; }

        public double AverageSessionDuration { get; set; }

        public ExerciseIntensity Intensity { get; set; }

        public static ExerciseRegimenParameters Build(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity) => new ExerciseRegimenParameters(sessionsPerWeek, averageSessionDuration, intensity);
    }
}