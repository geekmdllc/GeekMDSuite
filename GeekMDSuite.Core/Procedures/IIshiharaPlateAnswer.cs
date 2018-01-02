using GeekMDSuite.Core.Analytics.Classification;

namespace GeekMDSuite.Core.Procedures
{
    public interface IIshiharaPlateAnswer
    {
        int PlateNumber { get; set; }
        IshiharaAnswerResult PlateRead { get; set; }
    }
}