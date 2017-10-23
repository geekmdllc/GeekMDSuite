using System;
using GeekMDSuite.Contracts;

namespace GeekMDSuite.Calculations
{
    public static class FitTreadmillScore
    {
        public static double CalculateScore(
            Gender gender, 
            double metabolicEquivalents, 
            double ageInYears, 
            double percentMaxHeartRateReached)
        {
            double score = percentMaxHeartRateReached + 12 * metabolicEquivalents - 4 * ageInYears;
            
            switch(gender) {
                case Gender.Female:
                case Gender.NonBinaryXx:
                    score += 43;
                    break;
                case Gender.Male:
                case Gender.NonBinaryXy:
                    break;
                default:
                    throw new NotImplementedException(nameof(CalculateScore) + " in " + 
                                                      nameof(FitTreadmillScore) + " does not implement " + 
                                                      gender + ".");
            }
            return score;
        }

        public static int TenYearMortality(double fitTreadmillScore)
        {
            if (fitTreadmillScore <= -100) {
                return 38;
            }
            if (fitTreadmillScore <= 0) {
                return 11;
            }
            return fitTreadmillScore < 100 ? 3 : 2;
        }
    }
}