namespace GeekMDSuite.Core.Models
{
    public class BloodPressure
    {
        protected BloodPressure(int systolic, int diastolic, bool organDamage) : this()
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        public BloodPressure()
        {
        }

        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public bool OrganDamage { get; set; }

        public static BloodPressure Build(int systolic, int diastolic, bool organDamage = false)
        {
            return new BloodPressure(systolic, diastolic, organDamage);
        }

        public override string ToString()
        {
            return $"{Systolic}/{Diastolic} mmHg";
        }
    }
}