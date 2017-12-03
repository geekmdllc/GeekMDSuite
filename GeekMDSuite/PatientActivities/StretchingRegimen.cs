namespace GeekMDSuite.PatientActivities
{
    public class StretchingRegimen : ExerciseRegimen
    {
        public StretchingRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity) 
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
        }
    }
}