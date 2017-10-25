using System;

namespace GeekMDSuite.Contracts
{
    public class TimeDuration
    {
        public TimeDuration(double minutes, double seconds)
        {
            ValidateTimeArguments(Minutes, Seconds);
            Minutes = minutes;
            Seconds = seconds;
        }

        public double Minutes { get; private set; }
        public double Seconds { get; private set; }
        public double FractionalMinutes => Minutes + Seconds / 60;
        public double TotalSeconds => Minutes * 60 + Seconds;
        
        private static void ValidateTimeArguments(double minutes, double seconds)
        {
            if (minutes <= 0) throw new ArgumentOutOfRangeException(nameof(minutes));
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));
        }
    }
}