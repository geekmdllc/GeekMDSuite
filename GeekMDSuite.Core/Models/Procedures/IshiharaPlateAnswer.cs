namespace GeekMDSuite.Core.Models.Procedures
{
    public class IshiharaPlateAnswer
    {
        private IshiharaPlateAnswer(int plateNumber, IshiharaAnswerResult plateRead)
        {
            PlateNumber = plateNumber;
            PlateRead = plateRead;
        }

        protected internal IshiharaPlateAnswer()
        {
        }

        public int PlateNumber { get; set; }
        public IshiharaAnswerResult PlateRead { get; set; }

        internal static IshiharaPlateAnswer Build(int plateNumber, IshiharaAnswerResult plateRead)
        {
            return new IshiharaPlateAnswer(plateNumber, plateRead);
        }

        public override string ToString()
        {
            return $"#{PlateNumber} - {PlateRead}";
        }
    }
}