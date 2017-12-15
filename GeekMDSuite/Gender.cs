namespace GeekMDSuite
{
    public class Gender : IGender
    {
        public Gender(GenderIdentity category)
        {
            Category = category;
        }

        public GenderIdentity Category { get; }
        
        public Genotype Genotype => IsGenotypeXx(Category) ? Genotype.Xx : Genotype.Xy;

        public static bool IsGenotypeXx(GenderIdentity gender)
        {
            return gender == GenderIdentity.Female || gender == GenderIdentity.NonBinaryXx;
        }

        public static bool IsGenotypeXx(IGender gender)
        {
            return IsGenotypeXx(gender.Category);
        }
        
        public static bool IsGenotypeXy(GenderIdentity gender)
        {
            return !IsGenotypeXx(gender);
        }

        public static bool IsGenotypeXy(IGender gender)
        {
            return !IsGenotypeXx(gender.Category);
        }
    }
}