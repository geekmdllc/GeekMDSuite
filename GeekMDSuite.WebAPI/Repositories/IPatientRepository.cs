using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;

namespace GeekMDSuite.WebAPI.Repositories
{
    public interface IPatientRepository
    {
        PatientEntity FindById(int id);
        IEnumerable<PatientEntity> All();
        IEnumerable<PatientEntity> FindByName(string query);
        IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query);
        void Add(PatientEntity patient);
    }
}