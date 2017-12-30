using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class BloodPressureEntity : BloodPressure, IVisitData<BloodPressure>
    {
        public int Id { get; set; }
        public Guid Visit { get; set; }

        public BloodPressureEntity() {}

        public BloodPressureEntity(BloodPressure bloodPressure)
        {
            MapValues(bloodPressure);
        }
        
        public void MapValues(BloodPressure subject)
        {
            Diastolic = subject.Diastolic;
            Systolic = subject.Systolic;
            OrganDamage = subject.OrganDamage;
        }
    }
}