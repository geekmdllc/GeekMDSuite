namespace GeekMDSuite.Common
{
    public class PhysicalCharacteristics
    {
        public Gender Gender { get; private set; }
        public Races Race { get; private set; }
        public Weight Weight { get; private set; }
        public Height Height { get; private set; }
        public Waist Waist { get; private set; }
        
        
        public PhysicalCharacteristics(Gender gender, Races race, Weight weight, Height height, Waist waist)
        {
            Gender = gender;
            Race = race;
            Weight = weight;
            Height = height;
            Waist = waist;
        }

        public bool IsXx => Gender.IsGenotypeXx(Gender);
        public bool IsXy => Gender.IsGenotypeXy(Gender);
    }
}