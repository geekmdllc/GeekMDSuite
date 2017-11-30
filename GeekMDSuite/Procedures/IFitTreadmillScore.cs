using GeekMDSuite.Procedures;

namespace GeekMDSuite
{
    public interface IFitTreadmillScore
    {
        double Value { get; }
        FitTreadmillScoreMortality Classification { get; }
        int TenYearMortality { get; }
    }
}