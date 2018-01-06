namespace GeekMDSuite.Core.Models.Procedures
{
    public class IshiharaPlateAnswer 
    {

        internal static IshiharaPlateAnswer Build(int plateNumber, IshiharaAnswerResult plateRead) => 
            new IshiharaPlateAnswer(plateNumber, plateRead);

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

        public override string ToString() => $"#{PlateNumber} - {PlateRead}";
    }
}