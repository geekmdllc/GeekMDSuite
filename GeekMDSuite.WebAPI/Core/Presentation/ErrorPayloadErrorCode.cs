namespace GeekMDSuite.WebAPI.Core.Presentation
{
    public enum ErrorPayloadErrorCode
    {
        PatientNotFoundByGuidInRepository = 0,
        PatientNotFoundByIdInRepository = 1,
        PatientNotFoundByNameInRepository = 2,
        PatientNotFoundByMedicalRecordNumberInRepository = 3,
        PatientRepositoryEmpty = 4,
        RepositoryEntityNotFound = 5,
        VisitNotFoundInRepository = 6,
        PatientReceivedWithEmptyGuid = 7,
        VisitDataFromClientIsInvalid = 8,
        PatientStubFromUserIsInvalid = 9,
        MedicalRecordNumberIsNotUniqe = 10
    }
}