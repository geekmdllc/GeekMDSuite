namespace GeekMDSuite.Common
{
    public class Gender
    {
        public Genders Category { get; set; }

        public static bool IsXx(Genders gender)
        {
            return gender == Genders.Female || gender == Genders.NonBinaryXx;
        }

        public static bool IsXy(Genders gender)
        {
            return !IsXx(gender);
        }

        public static bool IsXx(Gender gender)
        {
            return IsXx(gender.Category);
        }

        public static bool IsXy(Gender gender)
        {
            return !IsXx(gender.Category);
        }
    }
}