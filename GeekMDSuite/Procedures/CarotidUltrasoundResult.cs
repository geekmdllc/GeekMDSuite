namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasoundResult : ICarotidUltrasoundResult
    {
        private CarotidUltrasoundResult(double intimaMediaMeasurementMillimeters, CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character, CarotidPercentStenosisGrade stenosis)
        {
            IntimaMediaMeasurementMillimeters = intimaMediaMeasurementMillimeters;
            Grade = grade;
            Character = character;
            Stenosis = stenosis;
        }

        public CarotidUltrasoundResult()
        {
            
        }

        public double IntimaMediaMeasurementMillimeters { get; set; }
        public CarotidIntimaMediaThicknessGrade Grade { get; set; }
        public CarotidPlaqueCharacter Character { get; set; }
        public CarotidPercentStenosisGrade Stenosis { get; set; }

        public static CarotidUltrasoundResult Build(double intimaMediaMeasurementMillimeters,
            CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character,
            CarotidPercentStenosisGrade stenosis) => 
            new CarotidUltrasoundResult(intimaMediaMeasurementMillimeters, grade, character, stenosis);

        public override string ToString() => 
            $"{IntimaMediaMeasurementMillimeters}mm {Grade} IMT thickening {Stenosis} stenosis {Character} character";
    }
}