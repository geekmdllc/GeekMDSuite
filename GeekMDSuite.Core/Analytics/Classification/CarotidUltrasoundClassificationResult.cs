using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class CarotidUltrasoundClassificationResult
    {
        public CarotidUltrasoundClassificationResult(
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

        public override string ToString() 
            => $"Laterality: {Laterality}, Worse: {WorseSide}, Stenosis Grade: {Grade}, PlaqueCharacter: {Character}";
    }
}