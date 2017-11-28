namespace GeekMDSuite
{
    public interface IGender
    {
        GenderIdentity Category { get; }
        Genotype Genotype { get; }
    }
}