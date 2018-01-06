using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Tools.Cardiology
{
    public partial class PooledCohortsEquation
    {
        public double IdealAscvdLifetimeRiskPercentage => Gender.IsGenotypeXy(_patient.Gender) ? AscvdLifetimeRiskPercentages.Male.Optimal : AscvdLifetimeRiskPercentages.Female.Optimal;

        public double AscvdLifetimeRiskPercentage
        {
            get
            {
                if (MajorPoints >= 2) return Gender.IsGenotypeXy(_patient.Gender) ? AscvdLifetimeRiskPercentages.Male.TwoMajor : AscvdLifetimeRiskPercentages.Female.TwoMajor;
                if (MajorPoints == 1) return Gender.IsGenotypeXy(_patient.Gender) ? AscvdLifetimeRiskPercentages.Male.OneMajor : AscvdLifetimeRiskPercentages.Female.OneMajor;
                if (Elevated) return Gender.IsGenotypeXy(_patient.Gender) ? AscvdLifetimeRiskPercentages.Male.Elevated : AscvdLifetimeRiskPercentages.Female.Elevated;
                if (NotOptimal) return Gender.IsGenotypeXy(_patient.Gender) ? AscvdLifetimeRiskPercentages.Male.NotOptimal : AscvdLifetimeRiskPercentages.Female.NotOptimal;

                return IdealAscvdLifetimeRiskPercentage;
            }
        }

        private bool NotOptimal => (_totalCholesterol.Result >= 180 || _bloodPressure.Systolic >= 120) && !_hypertensionTreatment;

        private bool Elevated => (_totalCholesterol.Result >= 200 || _bloodPressure.Systolic >= 140) && !_hypertensionTreatment;

        private int MajorPoints => (_totalCholesterol.Result >= 240 ? 1 : 0) +
                                   (_bloodPressure.Systolic >= 160 ? 1 : 0) +
                                   (_hypertensionTreatment ? 1 : 0) +
                                   (_diabetic ? 1 : 0) +
                                   (_smoker ? 1 : 0);

        public static class AscvdLifetimeRiskPercentages
        {
            public static class Male
            {
                public const double TwoMajor = 69;
                public const double OneMajor = 50;
                public const double Elevated = 46;
                public const double NotOptimal = 36;
                public const double Optimal = 5;
            }
            public static class Female
            {
                public const double TwoMajor = 50;
                public const double OneMajor = 39;
                public const double Elevated = 39;
                public const double NotOptimal = 27;
                public const double Optimal = 8;
            }
        }
    }
}