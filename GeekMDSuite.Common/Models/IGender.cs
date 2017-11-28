namespace GeekMDSuite.Common.Models
{
    public interface IGender
    {
        GenderIdentity Category { get; }
        Genotype Genotype { get; }
    }
}