namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasoundResult
    {
        public CarotidUltrasoundResult(double intimaMediaMeasurementMillimeters, CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character, CarotidPercentStenosisGrade stenosis)
        {
            IntimaMediaMeasurementMillimeters = intimaMediaMeasurementMillimeters;
            Grade = grade;
            Character = character;
            Stenosis = stenosis;
        }

        public double IntimaMediaMeasurementMillimeters { get; }
        public CarotidIntimaMediaThicknessGrade Grade { get; }
        public CarotidPlaqueCharacter Character { get; }
        public CarotidPercentStenosisGrade Stenosis { get; }
    }
}