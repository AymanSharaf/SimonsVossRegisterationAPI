using SimmonsVoss.RegistrationApp.Licenses;

namespace SimmonsVoss.RegistrationApp.LicenseRegisterationRequests.Events
{
    public class NewLicenseRegistrationRequestEvent
    {
        public LicenseId LicenseId { get; set; }
        public LicenseRegistrationRequestId LicenseRegistrationRequestId { get; set; }

        public NewLicenseRegistrationRequestEvent(LicenseId licenseId, LicenseRegistrationRequestId licenseRegistrationRequestId)
        {
            LicenseId = licenseId;
            LicenseRegistrationRequestId = licenseRegistrationRequestId;
        }
    }
}
