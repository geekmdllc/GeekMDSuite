namespace GeekMDSuite.PatientActivities
{
    public class ExerciseRegimenParameters : IExerciseRegimenParameters
    {
        public ExerciseRegimenParameters(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }

        public double SessionsPerWeek { get; }

        public double AverageSessionDuration { get; }

        public ExerciseIntensity Intensity { get; }
    }
}