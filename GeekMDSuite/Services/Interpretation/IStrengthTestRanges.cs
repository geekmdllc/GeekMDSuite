namespace GeekMDSuite.Services.Interpretation
{
    internal interface IStrengthTestRanges
    {
        int LowerLimitOfPoor { get;  }
        int LowerLimitOfBelowAverage { get;  }
        int LowerLimitOfAverage { get;  }
        int LowerLimitOfAboveAverage { get;  }
        int LowerLimitOfGood { get;  }
        int LowerLimitOfExcellent { get;  }
    }
}