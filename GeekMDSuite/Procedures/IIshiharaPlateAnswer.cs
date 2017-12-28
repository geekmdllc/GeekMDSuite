using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public interface IIshiharaPlateAnswer
    {
        int PlateNumber { get; }
        IshiharaAnswerResult PlateRead { get; }
    }
}