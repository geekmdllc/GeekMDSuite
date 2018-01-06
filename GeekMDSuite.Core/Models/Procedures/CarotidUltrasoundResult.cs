namespace GeekMDSuite.Core.Models.Procedures
{
    public class CarotidUltrasoundResult
    {
        private CarotidUltrasoundResult(double intimaMediaMeasurementMillimeters,
            CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character,
            CarotidPercentStenosisGrade stenosis)
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
            CarotidPercentStenosisGrade stenosis)
        {
            return new CarotidUltrasoundResult(intimaMediaMeasurementMillimeters, grade, character, stenosis);
        }

        public override string ToString()
        {
            return
                $"{IntimaMediaMeasurementMillimeters}mm {Grade} IMT thickening {Stenosis} stenosis {Character} character";
        }
    }
}