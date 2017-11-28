namespace GeekMDSuite.Models
{
    public class Gender : IGender
    {
        public Gender(GenderIdentity category)
        {
            Category = category;
            Genotype = IsGenotypeXx(category) ? Genotype.Xx : Genotype.Xy;
        }

        public GenderIdentity Category { get; }
        
        public Genotype Genotype { get; }

        public static bool IsGenotypeXx(GenderIdentity gender)
        {
            return gender == GenderIdentity.Female || gender == GenderIdentity.NonBinaryXx;
        }

        public static bool IsGenotypeXy(GenderIdentity gender)
        {
            return !IsGenotypeXx(gender);
        }

        public static bool IsGenotypeXx(IGender gender)
        {
            return IsGenotypeXx(gender.Category);
        }

        public static bool IsGenotypeXy(IGender gender)
        {
            return !IsGenotypeXx(gender.Category);
        }
    }
}