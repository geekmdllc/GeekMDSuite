using System.Collections.Generic;

namespace GeekMDSuite.PatientActivities
{
    public interface IResistanceRegimen : IExerciseRegimenParameters
    {
        int SecondsRestDurationPerSet { get; }
        List<ResistenceRegimenFeatures> Features { get; }
    }
}