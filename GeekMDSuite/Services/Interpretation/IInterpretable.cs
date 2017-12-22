namespace GeekMDSuite.Services.Interpretation
{
    public interface IInterpretable<out T>
    {
        InterpretationText Interpretation { get; }
        T Classification { get; }
    }
}