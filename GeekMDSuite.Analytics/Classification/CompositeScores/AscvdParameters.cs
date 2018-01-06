using System;
using System.ComponentModel;
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
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            BloodPressure = bloodPressure ?? throw new ArgumentNullException(nameof(bloodPressure));
            TotalCholesterol = totalCholesterol ?? throw new ArgumentNullException(nameof(totalCholesterol));
            LdlCholesterol = ldlCholesterol ?? throw new ArgumentNullException(nameof(ldlCholesterol));
            HdlCholesterol = hdlCholesterol ?? throw new ArgumentNullException(nameof(hdlCholesterol));
            
            if (totalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum)
                throw new InvalidEnumArgumentException($"{nameof(totalCholesterol.Type)}. Should be {nameof(QuantitativeLabType.CholesterolTotalSerum)}");
            if (ldlCholesterol.Type != QuantitativeLabType.LowDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(ldlCholesterol.Type)}. Should be {nameof(QuantitativeLabType.LowDensityLipoproteinSerum)}");
            if (hdlCholesterol.Type != QuantitativeLabType.HighDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(hdlCholesterol.Type)}. Should be {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}");
        }

        public AscvdParameters()
        {
            Patient = new Patient();
            BloodPressure = new BloodPressure();
            TotalCholesterol = new QuantitativeLab() { Type = QuantitativeLabType.CholesterolTotalSerum};
            HdlCholesterol = new QuantitativeLab() { Type = QuantitativeLabType.HighDensityLipoproteinSerum};
            LdlCholesterol = new QuantitativeLab() { Type = QuantitativeLabType.LowDensityLipoproteinSerum };
        }

        public Patient Patient { get; set; }
        public BloodPressure BloodPressure { get; set; }
        public QuantitativeLab TotalCholesterol { get; set; }
        public QuantitativeLab LdlCholesterol { get; set; }
        public QuantitativeLab HdlCholesterol { get; set; }
        
        
    }
}