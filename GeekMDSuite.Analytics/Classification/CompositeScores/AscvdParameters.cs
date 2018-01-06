using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdParameters
    {
        public static AscvdParameters Build(Patient patient,
            BloodPressure bloodPressure,
            QuantitativeLab totalCholesterol,
            QuantitativeLab ldlCholesterol,
            QuantitativeLab hdlCholesterol)
        {
            return new AscvdParameters(patient, bloodPressure, totalCholesterol, ldlCholesterol, hdlCholesterol);
        }
        private AscvdParameters(Patient patient, 
            BloodPressure bloodPressure, 
            QuantitativeLab totalCholesterol, 
            QuantitativeLab ldlCholesterol, 
            QuantitativeLab hdlCholesterol)
        {
            Patient = patient;
            BloodPressure = bloodPressure;
            TotalCholesterol = totalCholesterol;
            LdlCholesterol = ldlCholesterol;
            HdlCholesterol = hdlCholesterol;
        }

        internal AscvdParameters()
        {
            
        }

        public Patient Patient { get; set; }
        public BloodPressure BloodPressure { get; set; }
        public QuantitativeLab TotalCholesterol { get; set; }
        public QuantitativeLab LdlCholesterol { get; set; }
        public QuantitativeLab HdlCholesterol { get; set; }
        
        
    }
}