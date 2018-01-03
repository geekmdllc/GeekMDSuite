namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class TimeDuration
    {
        protected internal TimeDuration()
        {
            
        }

        private TimeDuration(double minutes, double seconds) : this()
        {
            Minutes = minutes;
            Seconds = seconds;
        }

        public double Minutes { get; set; }
        public double Seconds { get; set; }
        public double TotalSeconds => Minutes * 60 + Seconds;
        public double FractionalMinutes => TotalSeconds / 60;

        public static TimeDuration Build(double minutes, double seconds) => new TimeDuration(minutes, seconds);

        public override string ToString() => $"{Minutes}'{Seconds}\"";
    }
}