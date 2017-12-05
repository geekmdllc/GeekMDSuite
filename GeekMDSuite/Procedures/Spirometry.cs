namespace GeekMDSuite.Procedures
{
    public class Spirometry
    {
        public Spirometry(double forcedExpiratoryVolume1Second, 
            double forcedVitalCapacity, 
            double peakExpiratoryFlow, 
            double forcedExpiratoryFlow25To75, 
            double forcedExpiratoryTime)
        {
            ForcedExpiratoryVolume1Second = forcedExpiratoryVolume1Second;
            ForcedVitalCapacity = forcedVitalCapacity;
            PeakExpiratoryFlow = peakExpiratoryFlow;
            ForcedExpiratoryFlow25To75 = forcedExpiratoryFlow25To75;
            ForcedExpiratoryTime = forcedExpiratoryTime;
        }
        public double ForcedExpiratoryVolume1Second { get;  }
        public double ForcedVitalCapacity { get;  }
        public double PeakExpiratoryFlow { get; }
        public double ForcedExpiratoryFlow25To75 { get; }
        public double ForcedExpiratoryTime { get; }
        public double ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio =>
            ForcedExpiratoryVolume1Second / ForcedVitalCapacity;
    }
}