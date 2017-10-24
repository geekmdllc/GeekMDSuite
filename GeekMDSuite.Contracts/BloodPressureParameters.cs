namespace GeekMDSuite.Contracts
{
    public class BloodPressureParameters
    {
        public BloodPressureParameters(int systolic, int diastolic, bool organDamage)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            OrganDamage = organDamage;
        }

        public int Systolic { get; private set; }
        public int Diastolic { get; private set; }
        public bool OrganDamage { get; private set; }
    }
}