using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class BloodPressureEntity : BloodPressure, IVisitData<BloodPressure>
    {
        public BloodPressureEntity()
        {
            VisitId = Guid.Empty;
        }

        public BloodPressureEntity(BloodPressure bloodPressure) : this()
        {
            MapValues(bloodPressure);
        }

        public int Id { get; set; }
        public Guid VisitId { get; set; }

        public void MapValues(BloodPressure subject)
        {
            Diastolic = subject.Diastolic;
            Systolic = subject.Systolic;
            OrganDamage = subject.OrganDamage;
        }
    }
}