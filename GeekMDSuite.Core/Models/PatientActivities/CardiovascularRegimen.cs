namespace GeekMDSuite.Core.Models.PatientActivities
{
    public class CardiovascularRegimen : ExerciseRegimen
    {
        protected CardiovascularRegimen(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity)
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
        }

        public CardiovascularRegimen()
        {
        }

        public static CardiovascularRegimen Build(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity)
        {
            return new CardiovascularRegimen(sessionsPerWeek, averageSessionDuration, intensity);
        }
    }
}