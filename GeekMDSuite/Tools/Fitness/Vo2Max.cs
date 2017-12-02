using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Tools.Fitness
{
    public class Vo2Max
    {
        public Vo2Max(double value, FitnessClassification classification)
        {
            Value = value;
            Classification = classification;
        }

        public double Value { get; }
        public FitnessClassification Classification { get;  }
    }
}