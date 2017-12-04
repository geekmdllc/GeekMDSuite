namespace GeekMDSuite.Services.Interpretation
{
    public interface IInterpretable<T>
    {
        InterpretationText Interpretation { get; }
        T Classification { get; }
    }
}