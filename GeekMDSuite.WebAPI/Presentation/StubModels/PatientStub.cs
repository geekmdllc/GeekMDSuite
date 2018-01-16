using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class PatientStub : SelfLinkingStub
    {
        public PatientStub()
        {
            Comorbidities = new List<ChronicDisease>();
            Gender = new Gender();
            Name = new Name();
        }

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