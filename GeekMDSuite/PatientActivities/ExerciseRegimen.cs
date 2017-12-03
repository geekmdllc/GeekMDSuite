namespace GeekMDSuite.PatientActivities
{
    public abstract class ExerciseRegimen : IExerciseRegimenParameters
    {
        protected ExerciseRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
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