using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class TreadmillExerciseStressTestEntity : TreadmillExerciseStressTest,
        IMapProperties<TreadmillExerciseStressTest>, IVisitData
    {
        public TreadmillExerciseStressTestEntity()
        {
        }

        public TreadmillExerciseStressTestEntity(TreadmillExerciseStressTest treadmillExerciseStressTest)
        {
            MapValues(treadmillExerciseStressTest);
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }

        public void MapValues(TreadmillExerciseStressTest subject)
        {
            MaximumBloodPressure.Diastolic = subject.MaximumBloodPressure.Diastolic;
            MaximumBloodPressure.OrganDamage = subject.MaximumBloodPressure.OrganDamage;
            MaximumBloodPressure.Systolic = subject.MaximumBloodPressure.Systolic;
            MaximumHeartRate = subject.MaximumHeartRate;
            Protocol = subject.Protocol;
            SupineBloodPressure.Diastolic = subject.SupineBloodPressure.Diastolic;
            SupineBloodPressure.OrganDamage = subject.SupineBloodPressure.OrganDamage;
            SupineBloodPressure.Systolic = subject.SupineBloodPressure.Systolic;
            SupineHeartRate = subject.SupineHeartRate;
            Time.Minutes = subject.Time.Minutes;
            Time.Seconds = subject.Time.Seconds;
        }
    }
}