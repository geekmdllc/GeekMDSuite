namespace GeekMDSuite
{
    public class BloodPressure : IBloodPressure
    {
        private BloodPressure(int systolic, int diastolic, bool organDamage)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        public int Systolic { get; }
        public int Diastolic { get; }
        public bool OrganDamage { get; }

        public static BloodPressure Build(int systolic, int diastolic, bool organDamage = false) => 
            new BloodPressure(systolic, diastolic, organDamage);

        public override string ToString() => $"{Systolic}/{Diastolic} mmHg";
    }
}