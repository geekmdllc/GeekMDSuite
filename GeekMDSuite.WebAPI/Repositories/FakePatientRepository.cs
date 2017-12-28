using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Helpers;
using GeekMDSuite.WebAPI.Models;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class FakePatientRepository : IPatientRepository
    {
        public PatientEntity FindById(int id)
        { 
            try
            {
                return _fakeRepository.First(p => p.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<PatientEntity> All() => _fakeRepository;

        public IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query) => 
            _fakeRepository.Where(p => query.Equals(p.MedicalRecordNumber));
        
        public void Add(PatientEntity patient) => _fakeRepository.Append(patient);

        public IEnumerable<PatientEntity> FindByName(string query)  => 
            _fakeRepository.Where(p => StringHelpers.StringContainsQuery(query, p.Name.ToString()));

        public FakePatientRepository()
        {
            _fakeRepository = new List<PatientEntity>()
            {
                new PatientEntity(PatientBuilder.Initialize()
                    .SetDateOfBirth(1983, 6, 29)
                    .SetGender(GenderIdentity.Male)
                    .SetMedicalRecordNumber("1234567890")
                    .SetName("Joe", "Blow")
                    .SetRace(Race.White)
                    .Build()),
                new PatientEntity(PatientBuilder.Initialize()
                    .SetDateOfBirth(1905, 3, 13)
                    .SetGender(GenderIdentity.Female)
                    .SetMedicalRecordNumber("0987654321")
                    .SetName("Jane", "Doe")
                    .SetRace(Race.BlackOrAfricanAmerican)
                    .Build()),
                new PatientEntity(PatientBuilder.Initialize()
                    .SetDateOfBirth(1933, 9, 22)
                    .SetGender(GenderIdentity.NonBinaryXx)
                    .SetMedicalRecordNumber("11223445")
                    .SetName("Xer", "Doe", "Dane")
                    .SetRace(Race.Asian)
                    .Build())
            };
            var i = 0;
            foreach (var entry in _fakeRepository) entry.Id = i++;
        }

        private static IEnumerable<PatientEntity> _fakeRepository;
    }
}