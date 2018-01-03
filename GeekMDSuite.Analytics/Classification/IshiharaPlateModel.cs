namespace GeekMDSuite.Analytics.Classification
{
    public class IshiharaPlateModel 
    {
        public int PlateNumber { get; }
        public IshiharaPlateType PlateType  { get; }
        public string NormalVisionRead { get; }
        public string RedGreenDeficientRead { get; }
        public string TotalColorBlindnessRead { get; }

        public IshiharaPlateModel(int plateNumber, IshiharaPlateType plateType, 
            string normalVisionRead, string redGreenDeficientRead, string totalColorBindnessRead) 
        {
            PlateNumber = plateNumber;
            PlateType = plateType;
            NormalVisionRead = normalVisionRead;
            RedGreenDeficientRead = redGreenDeficientRead;
            TotalColorBlindnessRead = totalColorBindnessRead;
        }
    }
}