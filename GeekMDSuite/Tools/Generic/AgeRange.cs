namespace GeekMDSuite.Tools.Generic
{
    public class AgeRange {
        //TODO: convert to interval
        public AgeRange(int upper, int lower)
        {
            Upper = upper;
            Lower = lower;
        }

        public int Upper { get;}
        public int Lower { get;}
    }
}