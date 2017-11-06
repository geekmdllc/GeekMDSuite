namespace GeekMDSuite.Common
{
    public class CardiovascularRegimen
    {
        public CardiovascularRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity)
        {
            SessionsPerWeek = sessionsPerWeek;
            AverageSessionDuration = averageSessionDuration;
            Intensity = intensity;
        }

        public double SessionsPerWeek { get; private set; }
        public double AverageSessionDuration { get; private set; }
        public ExerciseIntensity Intensity { get; private set; }

        public double TotalMinutes => SessionsPerWeek * AverageSessionDuration;
    }
}