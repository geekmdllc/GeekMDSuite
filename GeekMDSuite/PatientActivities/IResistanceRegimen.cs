using System.Collections.Generic;

namespace GeekMDSuite.PatientActivities
{
    public interface IResistanceRegimen
    {
        int SecondsRestDurationPerSet { get; }
        List<ResistenceRegimenFeatures> Features { get; }
    }
}