namespace GeekMDSuite.Procedures
{
    public class Spirometry
    {
        internal static Spirometry Build(double forcedExpiratoryVolume1Second,
            double forcedVitalCapacity,
            double peakExpiratoryFlow,
            double forcedExpiratoryFlow25To75,
            double forcedExpiratoryTime)
        {
            return new Spirometry(forcedExpiratoryVolume1Second, forcedVitalCapacity, 
                peakExpiratoryFlow, forcedExpiratoryFlow25To75, forcedExpiratoryTime);
        }
        private Spirometry(double forcedExpiratoryVolume1Second, 
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

        public override string ToString() => 
            $"FEV1 {ForcedExpiratoryVolume1Second} L, FVC {ForcedVitalCapacity} L, FEF25-75 {ForcedExpiratoryFlow25To75} L/s " +
            $"PET {PeakExpiratoryFlow} L/s, FET {ForcedExpiratoryTime} sec, FEV1:FVC {ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio}";
    }
}