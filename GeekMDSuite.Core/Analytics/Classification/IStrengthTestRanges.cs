namespace GeekMDSuite.Core.Analytics.Classification
{
    internal interface IStrengthTestRanges
    {
        double LowerLimitOfPoor { get;  }
        double LowerLimitOfBelowAverage { get;  }
        double LowerLimitOfAverage { get;  }
        double LowerLimitOfAboveAverage { get;  }
        double LowerLimitOfGood { get;  }
        double LowerLimitOfExcellent { get;  }
    }
}