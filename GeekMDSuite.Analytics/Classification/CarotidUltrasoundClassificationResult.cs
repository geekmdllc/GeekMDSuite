using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class CarotidUltrasoundClassificationResult
    {
        public CarotidUltrasoundClassificationResult(
            CarotidUltrasound carotidUltrasound,
            Laterality laterality,
            Laterality worseSide,
            CarotidPercentStenosisGrade grade,
            CarotidPlaqueCharacter character)
        {
            CarotidUltrasound = carotidUltrasound;
            WorseSide = worseSide;
            Grade = grade;
            Character = character;
            Laterality = laterality;
        }

        public CarotidUltrasound CarotidUltrasound { get; }
        public Laterality WorseSide { get; }
        public Laterality Laterality { get; }
        public CarotidPercentStenosisGrade Grade { get; }
        public CarotidPlaqueCharacter Character { get; }

        public override string ToString()
        {
            return
                $"Laterality: {Laterality}, Worse: {WorseSide}, Stenosis Grade: {Grade}, PlaqueCharacter: {Character}";
        }
    }
}