using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Procedures
{
    public class IshiharaPlateAnswer {

        private IshiharaPlateAnswer(int plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }
        public int PlateNumber { get; }
        public IshiharaAnswerResult PlateRead { get;  }

        internal static IshiharaPlateAnswer Build(int plateNumber, IshiharaAnswerResult plateRead) => 
            new IshiharaPlateAnswer(plateNumber, plateRead);

        public override string ToString() => $"#{PlateNumber} - {PlateRead}";
    }
}