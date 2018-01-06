﻿namespace GeekMDSuite.Core.Models.PatientActivities
{
    public class CardiovascularRegimen : ExerciseRegimen
    {
        private CardiovascularRegimen(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity)
            : base(sessionsPerWeek, averageSessionDuration, intensity)
        {
        }

        public static CardiovascularRegimen Build(double sessionsPerWeek, double averageSessionDuration,
            ExerciseIntensity intensity)
        {
            return new CardiovascularRegimen(sessionsPerWeek, averageSessionDuration, intensity);
        }
    }
}