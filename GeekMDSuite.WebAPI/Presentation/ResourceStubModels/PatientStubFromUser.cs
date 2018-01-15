using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.WebAPI.Presentation.ResourceStubModels
{
    public class PatientStubFromUser
    {
        public PatientStubFromUser()
        {
            Comorbidities = new List<ChronicDisease>();
            Gender = new Gender();
            Name = new Name();
        }

        [Required]
        public Guid Guid { get; set; }
        [Required]
        public Name Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int Age => DateOfBirth.ElapsedYears();
        [Required]
        public string MedicalRecordNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Race Race { get; set; }
        public List<ChronicDisease> Comorbidities { get; set; }
    }
}