namespace GeekMDSuite.Common
{
    public class PhysicalCharacteristics
    {
        public Gender Gender { get; private set; }
        public Race Race { get; private set; }
        public Weight Weight { get; private set; }
        public Height Height { get; private set; }
        public Waist Waist { get; private set; }
        
        
        public PhysicalCharacteristics(Gender gender, Race race, Weight weight, Height height, Waist waist)
        {
            Gender = gender;
            Race = race;
            Weight = weight;
            Height = height;
            Waist = waist;
        }

        public bool IsXx => Gender.IsXx(Gender);
        public bool IsXy => Gender.IsXy(Gender);
    }
}