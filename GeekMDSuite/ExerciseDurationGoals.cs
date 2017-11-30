namespace GeekMDSuite
{
    public struct ExerciseDurationGoals
    {
        public ExerciseDurationGoals(double moderateIntensity, double highIntensity)
        {
            ModerateIntensity = moderateIntensity;
            HighIntensity = highIntensity;
        }
        public double ModerateIntensity { get;  }
        public double HighIntensity { get;  }
        
    }
}