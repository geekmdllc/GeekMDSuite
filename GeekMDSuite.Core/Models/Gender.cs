using System;

namespace GeekMDSuite.Core.Models
{
    public class Gender
    {
        public Gender()
        {
        }

        private Gender(GenderIdentity category)
        {
            Category = category;
        }

        public GenderIdentity Category { get; set; }

        public Genotype Genotype => GetGenotype(Category);

        public static Genotype GetGenotype(GenderIdentity category)
        {
            return IsGenotypeXx(category) ? Genotype.Xx : Genotype.Xy;
        }

        public static bool IsGenotypeXx(GenderIdentity gender)
        {
            return gender == GenderIdentity.Female || gender == GenderIdentity.NonBinaryXx;
        }

        public static bool IsGenotypeXx(Gender gender)
        {
            return IsGenotypeXx(gender.Category);
        }

        public static bool IsGenotypeXy(GenderIdentity gender)
        {
            return !IsGenotypeXx(gender);
        }

        public static bool IsGenotypeXy(Gender gender)
        {
            if (gender == null) throw new ArgumentNullException(nameof(gender));
            return !IsGenotypeXx(gender.Category);
        }

        public static Gender Build(GenderIdentity category)
        {
            return new Gender(category);
        }

        public override string ToString()
        {
            return Category.ToString();
        }
    }
}