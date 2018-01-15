using System;
using System.ComponentModel.DataAnnotations;
using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class VisitStubFromUser
    {
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public VisitStatus Status { get; set; }
        [Required]
        public Guid PatientGuid { get; set; }
    }
}