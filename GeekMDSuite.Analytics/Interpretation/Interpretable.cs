namespace GeekMDSuite.Analytics.Interpretation
{
    public abstract class Interpretable
    {
        public abstract InterpretationText Interpretation { get; }

        public override string ToString() => Interpretation.ToString();
    }
}