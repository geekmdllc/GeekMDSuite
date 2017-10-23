using System;
using GeekMDSuite.Contracts;

namespace GeekMDSuite.Interpretation.Procedures
{
    public static class Vo2Max
    {
        public static FitnessClassification Interpret(double vo2Max, Gender gender, double ageInYears)
        {
            // http://www.topendsports.com/testing/norms/vo2max.htm
            switch(gender) {
                case Gender.Female:
                case Gender.NonBinaryXx:
                    if(ageInYears <= 25) {
                        if(vo2Max > 56) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 47) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 42) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 38) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 33) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 28 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 35) {
                        if(vo2Max > 52) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 45) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 39) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 35) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 31) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 45) {
                        if(vo2Max > 45) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 38) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 34) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 31) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 27) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 55) {
                        if(vo2Max > 40) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 34) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 31) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 28) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 25) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 65) {
                        if(vo2Max > 37) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 32) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 28) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 25) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 22) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 18 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears > 65) {
                        if(vo2Max > 32) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 28) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 25) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 22) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 19) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 17 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    break;
                case Gender.Male:
                case Gender.NonBinaryXy:
                    if(ageInYears <= 25) {
                        if(vo2Max > 60) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 52) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 47) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 42) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 37) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 35) {
                        if(vo2Max > 56) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 49) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 43) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 40) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 35) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 45) {
                        if(vo2Max > 51) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 43) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 39) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 35) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 31) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 55) {
                        if(vo2Max > 45) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 39) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 36) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 32) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 29) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 25 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears <= 65) {
                        if(vo2Max > 41) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 36) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 32) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 30) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 26) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    if(ageInYears > 65) {
                        if(vo2Max > 37) {
                            return FitnessClassification.Excellent;
                        }
                        if(vo2Max >= 33) {
                            return FitnessClassification.Good;
                        }
                        if(vo2Max >= 29) {
                            return FitnessClassification.AboveAverage;
                        }
                        if(vo2Max >= 26) {
                            return FitnessClassification.Average;
                        }
                        if(vo2Max >= 22) {
                            return FitnessClassification.BelowAverage;
                        }
                        return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
                    }
                    break;
                default:
                    throw new NotImplementedException(nameof(FitnessClassification) + " in " + 
                                                      nameof(FitnessClassification) + 
                                                      " does not implement that gender.");
            }
            
            throw new ArgumentOutOfRangeException(nameof(Vo2Max) + "." + nameof(Interpret) + 
                                                  "(args) does not recognize the arguments supplied as valid.");
        }
    }
}