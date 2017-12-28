using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public class IshiharaPlateAnswer : IIshiharaPlateAnswer
    {

        internal static IshiharaPlateAnswer Build(int plateNumber, IshiharaAnswerResult plateRead) => 
            new IshiharaPlateAnswer(plateNumber, plateRead);

        private IshiharaPlateAnswer(int plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }
        public int PlateNumber { get; }
        public IshiharaAnswerResult PlateRead { get;  }

        public override string ToString() => $"#{PlateNumber} - {PlateRead}";
    }
}