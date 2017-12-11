namespace GeekMDSuite.Procedures
{
    internal class IshiharaPlateReadLimitsByScreenType
    {
        public IshiharaPlateReadLimitsByScreenType(int upperLimitOfFail, int lowerLimitOfPass, IshiharaTestType testType)
        {
            UpperLimitOfFail = upperLimitOfFail;
            LowerLimitOfPass = lowerLimitOfPass;
            SlidesToEvaluate = DetermineNumberOfSlidesToEvaluate(testType);
        }


        public int UpperLimitOfFail { get; }
        public int LowerLimitOfPass { get; }
        public int SlidesToEvaluate { get; }
        
        private static int DetermineNumberOfSlidesToEvaluate(IshiharaTestType testType)
        {
            if (testType == IshiharaTestType.Ishihara6) return 6;
            if (testType == IshiharaTestType.Ishihara10) return 10;
            if (testType == IshiharaTestType.Ishihara14) return 14;
            return testType == IshiharaTestType.Ishihara24 ? 24 : 38;
        }
    }
}