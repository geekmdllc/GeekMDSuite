using System.Collections.Generic;

namespace GeekMDSuite.WebAPI.TestRepositories
{
    public interface IPatientRepo
    {
        List<Patient> All { get; }
        List<Patient> SearchByName(string name);
        Patient SearchByMrn(string mrn);
    }
}