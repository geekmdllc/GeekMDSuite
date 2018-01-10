namespace GeekMDSuite.WebAPI.Core.Presentation
{
    public enum ErrorPayloadCode
    {
        PatientNotFoundByGuidInRepository = 0,
        PatientNotFoundByIdInRepository = 1,
        PatientNotFoundByNameInRepository = 2,
        PatientNotFoundByMedicalRecordNumberInRepository = 3,
        PatientRepositoryEmpty = 4,
        RepositoryEntityNotFound = 5
    }
}