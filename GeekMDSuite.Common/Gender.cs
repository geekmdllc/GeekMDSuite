namespace GeekMDSuite.Common
{
    public class Gender
    {
        public Gender(GenderIdentity category)
        {
            Category = category;
        }

        public GenderIdentity Category { get; set; }

        public static bool IsGenotypeXx(GenderIdentity gender)
        {
            return gender == GenderIdentity.Female || gender == GenderIdentity.NonBinaryXx;
        }

        public static bool IsGenotypeXy(GenderIdentity gender)
        {
            return !IsGenotypeXx(gender);
        }

        public static bool IsGenotypeXx(Gender gender)
        {
            return IsGenotypeXx(gender.Category);
        }

        public static bool IsGenotypeXy(Gender gender)
        {
            return !IsGenotypeXx(gender.Category);
        }
    }
}