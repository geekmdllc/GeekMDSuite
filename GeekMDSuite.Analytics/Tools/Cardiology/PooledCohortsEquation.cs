﻿using System;
using System.ComponentModel;
using GeekMDSuite.Core;
using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.Analytics.Tools.Cardiology
{
    public partial class PooledCohortsEquation
    {
        public static PooledCohortsEquation Initialize(PooledCohortEquationParameters parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            
            return new PooledCohortsEquation(parameters);
        }
        
        private PooledCohortsEquation(PooledCohortEquationParameters parameters)
        {
            _hdlCholesterol = parameters.HdlCholesterol ?? throw new ArgumentNullException(nameof(parameters.HdlCholesterol));
            _totalCholesterol = parameters.TotalCholesterol ?? throw new ArgumentNullException(nameof(parameters.TotalCholesterol));
            _bloodPressure = parameters.BloodPressure ?? throw new ArgumentNullException(nameof(parameters.BloodPressure));
            _patient = parameters.Patient ?? throw new ArgumentNullException(nameof(parameters.Patient));
            _hypertensionTreatment = parameters.HypertensionTreatment;
            _smoker = parameters.Smoker;
            _diabetic = parameters.Diabetic;
            
            if (parameters.TotalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum) 
                throw new InvalidEnumArgumentException($"{nameof(parameters.TotalCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.CholesterolTotalSerum)}.");
            if (parameters.HdlCholesterol.Type != QuantitativeLabType.HighDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(parameters.HdlCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}.");
        }
                
        private readonly Patient _patient;
        private readonly BloodPressure _bloodPressure;
        private readonly QuantitativeLab _totalCholesterol;
        private readonly QuantitativeLab _hdlCholesterol;
        private readonly bool _hypertensionTreatment;
        private readonly bool _smoker;
        private readonly bool _diabetic;
    }
}