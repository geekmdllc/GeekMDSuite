using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Fake
{
    public static partial class FakeGeekMdSuiteContextBuilder
    {
        private static List<PatientEntity> GetPatientEntities()
        {
            var p1 = PatientBuilder.Initialize()
                .SetDateOfBirth(1900, 1, 1)
                .SetGender(GenderIdentity.Male)
                .SetMedicalRecordNumber("12345")
                .SetName("Bruce", "Wayne")
                .SetRace(Race.White)
                .Build();

            var p2 = PatientBuilder.Initialize()
                .SetDateOfBirth(1990, 2, 2)
                .SetGender(GenderIdentity.NonBinaryXx)
                .SetMedicalRecordNumber("54321")
                .SetName("Xer", "Majesty")
                .SetRace(Race.Unknown)
                .Build();

            return new List<PatientEntity>()
            {
                new PatientEntity(p1) { Guid = Guid.Parse("3b69bd30-7a07-4859-b536-5071e0a5f516")},
                new PatientEntity(p2) { Guid = Guid.Parse("50345ee6-fde2-4a51-8177-8c715628e39e")}
            };
        }
    }
}