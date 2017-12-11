namespace GeekMDSuite.Services.Interpretation
{
    public class StrengthTestLowerLimits
    {
        public StrengthTestLowerLimits(
            int poor, 
            int belowAverage, 
            int average, 
            int aboveAverage, 
            int good, 
            int excellent)
        {
            Poor = poor;
            BelowAverage = belowAverage;
            Average = average;
            AboveAverage = aboveAverage;
            Good = good;
            Excellent = excellent;
        }

        public int Poor { get; }
        public int BelowAverage { get; }
        public int Average { get; }
        public int AboveAverage { get; }
        public int Good { get; }
        public int Excellent { get; }
    }
}