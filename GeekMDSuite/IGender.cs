namespace GeekMDSuite
{
    public interface IGender
    {
        GenderIdentity Category { get; set; }
        Genotype Genotype { get; }
    }
}