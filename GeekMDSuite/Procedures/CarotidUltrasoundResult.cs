namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasoundResult
    {
        private CarotidUltrasoundResult(double intimaMediaMeasurementMillimeters, CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character, CarotidPercentStenosisGrade stenosis)
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

        internal static CarotidUltrasoundResult Build(double intimaMediaMeasurementMillimeters,
            CarotidIntimaMediaThicknessGrade grade, CarotidPlaqueCharacter character,
            CarotidPercentStenosisGrade stenosis) => 
            new CarotidUltrasoundResult(intimaMediaMeasurementMillimeters, grade, character, stenosis);

        public override string ToString() => 
            $"{IntimaMediaMeasurementMillimeters}mm {Grade} IMT thickening {Stenosis} stenosis {Character} character";
    }
}