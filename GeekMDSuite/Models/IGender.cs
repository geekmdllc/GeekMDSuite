namespace GeekMDSuite.Models
{
    public interface IGender
    {
        GenderIdentity Category { get; }
        Genotype Genotype { get; }
    }
}