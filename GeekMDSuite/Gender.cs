namespace GeekMDSuite
{
    public class Gender : IGender
    {
        private Gender(GenderIdentity category)
        {
            Category = category;
        }

        public GenderIdentity Category { get; }
        
        public Genotype Genotype => IsGenotypeXx(Category) ? Genotype.Xx : Genotype.Xy;

        public static bool IsGenotypeXx(GenderIdentity gender) => 
            gender == GenderIdentity.Female || gender == GenderIdentity.NonBinaryXx;

        public static bool IsGenotypeXx(IGender gender) => IsGenotypeXx(gender.Category);

        public static bool IsGenotypeXy(GenderIdentity gender) => !IsGenotypeXx(gender);

        public static bool IsGenotypeXy(IGender gender) => !IsGenotypeXx(gender.Category);

        public static Gender Build(GenderIdentity category) => new Gender(category);

        public override string ToString()
        {
            return Category.ToString();
        }
    }
}