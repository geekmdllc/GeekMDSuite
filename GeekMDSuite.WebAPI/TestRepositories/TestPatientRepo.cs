using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.WebAPI.TestRepositories
{
    public class TestPatientRepo : IPatientRepo
    {
        public List<Patient> All => new List<Patient>()
        {
            PatientBuilder.Initialize()
                .SetDateOfBirth(1983, 6, 29)
                .SetGender(GenderIdentity.Male)
                .SetMedicalRecordNumber("1234567890")
                .SetName("Joe", "Blow")
                .SetRace(Race.White)
                .Build(),
            PatientBuilder.Initialize()
                .SetDateOfBirth(1905, 3, 13)
                .SetGender(GenderIdentity.Female)
                .SetMedicalRecordNumber("0987654321")
                .SetName("Jane", "Doe")
                .SetRace(Race.BlackOrAfricanAmerican)
                .Build(),
            PatientBuilder.Initialize()
                .SetDateOfBirth(1933, 9, 22)
                .SetGender(GenderIdentity.NonBinaryXx)
                .SetMedicalRecordNumber("11223445")
                .SetName("Xer", "Doe")
                .SetRace(Race.Asian)
                .Build()
        };

        public List<Patient> SearchByName(string name) => 
            All.Where(p => name.ToLower()
                               .Contains(p.Name.Last.ToLower()) || name.ToLower().Contains(p.Name.First.ToLower()))
                                .ToList();
        
        public Patient SearchByMrn(string mrn) => All.First(p => mrn.Equals(p.MedicalRecordNumber));
    }
}