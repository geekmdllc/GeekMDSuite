namespace GeekMDSuite
{
    public class BloodPressure
    {
        public BloodPressure(int systolic, int diastolic, bool organDamage)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        public int Systolic { get; }
        public int Diastolic { get; }
        public bool OrganDamage { get; }
    }
}