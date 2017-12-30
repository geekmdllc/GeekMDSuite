using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.Procedures
{
    public interface IIshiharaPlateAnswer
    {
        int PlateNumber { get; }
        IshiharaAnswerResult PlateRead { get; }
    }
}