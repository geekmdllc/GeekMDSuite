using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Utilities.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class TreadmillExerciseStressTestStubFromUser : IVisitData
    {
        public TreadmillExerciseStressTestStubFromUser()
        {
            Time = new TimeDuration();
            SupineBloodPressure = new BloodPressure();
            MaximumBloodPressure = new BloodPressure();
        }

        public TreadmillProtocol Protocol { get; set; }
        public TimeDuration Time { get; set; }
        public TmstResult Result { get; set; }
        public BloodPressure SupineBloodPressure { get; set; }
        public int SupineHeartRate { get; set; }
        public BloodPressure MaximumBloodPressure { get; set; }
        public int MaximumHeartRate { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}