using System.Collections.Generic;

namespace GeekMDSuite.Core.PatientActivities
{
    public interface IResistanceRegimen : IExerciseRegimenParameters
    {
        int SecondsRestDurationPerSet { get; set; }
        List<ResistenceRegimenFeatures> Features { get; set; }
    }
}