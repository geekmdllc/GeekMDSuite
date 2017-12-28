using System;

namespace GeekMDSuite
{
    public interface IPatient
    {
        DateTime DateOfBirth { get; set; }
        int Age { get; }
        Name Name { get; set; }
        string MedicalRecordNumber { get; set; }
        Gender Gender { get; set; }
        Race Race { get; set; }
    }
}