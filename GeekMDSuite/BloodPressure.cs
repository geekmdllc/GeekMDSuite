namespace GeekMDSuite
{
    public class BloodPressure : IBloodPressure
    {
        public BloodPressure()
        {
            
        }

        private BloodPressure(int systolic, int diastolic, bool organDamage)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }

        public static BloodPressure Build(int systolic, int diastolic, bool organDamage = false) => 
            new BloodPressure(systolic, diastolic, organDamage);

        public override string ToString() => $"{Systolic}/{Diastolic} mmHg";
    }
}