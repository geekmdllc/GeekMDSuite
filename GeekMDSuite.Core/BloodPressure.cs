namespace GeekMDSuite.Core
{
    public class BloodPressure : IBloodPressure
    {
        protected BloodPressure(int systolic, int diastolic, bool organDamage) : this()
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        protected internal BloodPressure()
        {
        }

        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }

        public static BloodPressure Build(int systolic, int diastolic, bool organDamage = false) => 
            new BloodPressure(systolic, diastolic, organDamage);

        public override string ToString() => $"{Systolic}/{Diastolic} mmHg";
    }
}