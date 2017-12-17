namespace GeekMDSuite.Procedures
{
    public class CarotidUltrasoundResultBuilder
    {

        public CarotidUltrasoundResult Build()
        {
            return CarotidUltrasoundResult.Build(_imtThickenssMm, _imtGrade, _plaqueCharacter, _stenosisGrade);
        }
        
        public CarotidUltrasoundResultBuilder SetIntimaMediaThickeness(double millimeters)
        {
            _imtThickenssMm = millimeters;
            return this;
        }

        public CarotidUltrasoundResultBuilder SetPercentStenosisGrade(CarotidPercentStenosisGrade grade)
        {
            _stenosisGrade = grade;
            return this;
        }
        
        public CarotidUltrasoundResultBuilder SetPlaqueCharacter(CarotidPlaqueCharacter character)
        {
            _plaqueCharacter = character;
            return this;
        }
        
        public CarotidUltrasoundResultBuilder SetImtGrade(CarotidIntimaMediaThicknessGrade grade)
        {
            _imtGrade = grade;
            return this;
        }
        
        private double _imtThickenssMm;
        private CarotidPercentStenosisGrade _stenosisGrade = CarotidPercentStenosisGrade.None;
        private CarotidPlaqueCharacter _plaqueCharacter = CarotidPlaqueCharacter.None;
        private CarotidIntimaMediaThicknessGrade _imtGrade = CarotidIntimaMediaThicknessGrade.Normal;
    }
}