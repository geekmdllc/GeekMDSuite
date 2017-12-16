using System;

namespace GeekMDSuite.Tools.MeasurementUnits
{
    public class TimeDuration : ITimeDuration
    {

        public TimeDuration(double seconds)
        {
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            TotalSeconds = seconds;
            Minutes = (int)TotalSeconds / 60;
            Seconds = (int)TotalSeconds % 60;
        }
        
        public TimeDuration(double minutes, double seconds) : this(minutes * 60 + seconds)
        { }

        public int Minutes { get; }
        public int Seconds { get; }
        public double TotalSeconds { get; }
        public double FractionalMinutes => TotalSeconds / 60;

        public static TimeDuration Create(double minutes, double seconds) => new TimeDuration(minutes, seconds);
    }
}