using FitnessClassification = GeekMDSuite.Services.Interpretation.FitnessClassification;

namespace GeekMDSuite.Tools.Fitness
{
    public class Vo2Max
    {
        private Vo2Max(double value, FitnessClassification classification)
        {
            Value = value;
            Classification = classification;
        }

        public double Value { get; }
        public FitnessClassification Classification { get;  }

        public static Vo2Max Build(double value, FitnessClassification classification) => new Vo2Max(value, classification);
    }
}