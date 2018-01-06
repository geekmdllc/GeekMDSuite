namespace GeekMDSuite.Core.Models.PatientActivities
{
    public class StretchingRegimen : ExerciseRegimen
    {
        private StretchingRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
        }

        public static StretchingRegimen Build(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity)
        {
            return new StretchingRegimen(sessionsPerWeek, averageSessionDuration, intensity);
        }
    }
}