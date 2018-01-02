using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.Core.Procedures
{
    public interface IIshiharaPlateAnswer
    {
        int PlateNumber { get; }
        IshiharaAnswerResult PlateRead { get; }
    }
}