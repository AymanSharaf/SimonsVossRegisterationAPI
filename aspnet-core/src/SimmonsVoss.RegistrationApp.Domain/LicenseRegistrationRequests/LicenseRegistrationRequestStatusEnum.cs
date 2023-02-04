namespace SimmonsVoss.RegistrationApp.LicenseRegisterationRequests
{
    public enum LicenseRegistrationRequestStatus
    {
        New,
        Completed,
        Failed, // I don't think the requst sould be failed
        SuspectedFruad,
        Rejected
    }
}
