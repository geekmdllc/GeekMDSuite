using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Utilities.MeasurementUnits;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class TreadmillExerciseStressTestStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public TreadmillProtocol Protocol { get; set; }
        public TimeDuration Time { get; set; }
        public TmstResult Result { get; set; }
        public BloodPressure SupineBloodPressure { get; set; }
        public int SupineHeartRate { get; set; }
        public BloodPressure MaximumBloodPressure { get; set; }
        public int MaximumHeartRate { get; set; }

        public TreadmillExerciseStressTestStub()
        {
            Time = new TimeDuration();
            SupineBloodPressure = new BloodPressure();
            MaximumBloodPressure = new BloodPressure();
        }
    }
}