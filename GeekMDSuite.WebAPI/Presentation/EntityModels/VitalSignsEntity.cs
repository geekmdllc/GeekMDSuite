using System;
using GeekMDSuite.Tools.MeasurementUnits;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class VitalSignsEntity : VitalSigns, IVisitData<VitalSigns>
    {
        public VitalSignsEntity()
        {        }

        public VitalSignsEntity(VitalSigns vitalSigns) : this()
        {
            MapValues(vitalSigns);
        }
        
        public void MapValues(VitalSigns subject)
        {
            BloodPressure.Diastolic = subject.BloodPressure.Diastolic;
            BloodPressure.OrganDamage = subject.BloodPressure.OrganDamage;
            BloodPressure.Systolic = subject.BloodPressure.Systolic;
            OxygenSaturation = subject.OxygenSaturation;
            PulseRate = subject.PulseRate;
            Temperature.Farenheit = subject.Temperature.Farenheit;
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}