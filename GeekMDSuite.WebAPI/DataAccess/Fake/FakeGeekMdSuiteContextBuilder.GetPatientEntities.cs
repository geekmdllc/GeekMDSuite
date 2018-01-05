using System.Collections.Generic;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<Patient> GetPatientEntities()
        {
            var p1 = PatientBuilder.Initialize()
                .SetDateOfBirth(1900, 1, 1)
                .SetGender(GenderIdentity.Male)
                .SetMedicalRecordNumber(BruceWaynesMedicalRecordNumber)
                .SetName("Bruce", "Wayne")
                .SetRace(Race.White)
                .Build();
            p1.Guid = BruceWaynesGuid;

            var p2 = PatientBuilder.Initialize()
                .SetDateOfBirth(1990, 2, 2)
                .SetGender(GenderIdentity.NonBinaryXx)
                .SetMedicalRecordNumber(XerMajestiesMedicalRecordNumber)
                .SetName("Xer", "Majesty")
                .SetRace(Race.Unknown)
                .AddComorbidity(ChronicDisease.Diabetes)
                .AddComorbidities(new List<ChronicDisease>(){ChronicDisease.Hyperlipidemia, ChronicDisease.HypertensionTreated})
                .Build();
            p2.Guid = XerMajestyGuid;

            return new List<Patient>() { p1 , p2 };
        }
    }
}