using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class PatientStub
    {
        public Guid Guid { get; set; }
        public Name Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateOfBirth.ElapsedYears();
        public string MedicalRecordNumber { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public List<ChronicDisease> Comorbidities { get; set; }
    }
}