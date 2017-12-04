using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class CarotidUltrasoundInterpretationResult
    {
        public CarotidUltrasoundInterpretationResult(Laterality laterality, CarotidPercentStenosisGrade grade)
        {
            Laterality = laterality;
            Grade = grade;
        }

        public Laterality Laterality { get; }
        public CarotidPercentStenosisGrade Grade { get; }
    }
}