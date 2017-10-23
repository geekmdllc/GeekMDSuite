using System;

namespace GeekMD.Objects
{
    public class TreadmillExerciseStressTestData
    {
        
    }
    public enum TreadmillStressTestProtocol
    {
        NoneSelected,
        Bruce,
        BruceLowLevel,
        ModifiedBruce,
        Balke3Point0,
        Balke3Point4,
        Cornell,
        Ellstad,
        Kattus,
        Naughton,
        UsAirforceSam20,
        UsAirforceSam33
    }
    public enum TreadmillStressTestResultFlag
    {
        NoneSelected,
        Normal,
        Ischemia,
        Abnormal,
        Other
    }
}