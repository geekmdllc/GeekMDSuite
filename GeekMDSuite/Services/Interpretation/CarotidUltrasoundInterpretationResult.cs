using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class CarotidUltrasoundInterpretationResult
    {
        public CarotidUltrasoundInterpretationResult(
            Laterality laterality, 
            Laterality worseSide, 
            CarotidPercentStenosisGrade grade, 
            CarotidPlaqueCharacter character)
        {
            WorseSide = worseSide;
            Grade = grade;
            Character = character;
            Laterality = laterality;
        }

        public Laterality WorseSide { get; }
        public Laterality Laterality { get; }
        public CarotidPercentStenosisGrade Grade { get; }
        public CarotidPlaqueCharacter Character { get; }
    }
}