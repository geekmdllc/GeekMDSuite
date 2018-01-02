namespace GeekMDSuite.Core
{
    public interface IGender
    {
        GenderIdentity Category { get; set; }
        Genotype Genotype { get; }
    }
}