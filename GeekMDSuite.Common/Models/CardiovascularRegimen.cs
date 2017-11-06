namespace GeekMDSuite.Common.Models
{
    public class CardiovascularRegimen : ExerciseRegimenBase
    {
        public CardiovascularRegimen(double sessionsPerWeek, double averageSessionDuration, ExerciseIntensity intensity) 
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
            Goals = new ExerciseDurationGoals
            {
                HighIntensity =  75,
                ModerateIntensity = 150
            };
        }

        public sealed override ExerciseDurationGoals Goals { get; protected set; }
    }
}