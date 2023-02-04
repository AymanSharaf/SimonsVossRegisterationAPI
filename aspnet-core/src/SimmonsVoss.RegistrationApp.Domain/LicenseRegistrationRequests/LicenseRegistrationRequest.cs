using SimmonsVoss.RegistrationApp.LicenseRegisterationRequests.Events;
using SimmonsVoss.RegistrationApp.Licenses;
using Volo.Abp.Domain.Entities.Auditing;

namespace SimmonsVoss.RegistrationApp.LicenseRegisterationRequests
{
    public class LicenseRegistrationRequest : AuditedAggregateRoot<LicenseRegistrationRequestId>
    {
        public Address Address { get; private set; }
        public ComapnyName ComapnyName { get; private set; }
        public Email Email { get; private set; }
        public ContactPerson ContactPerson { get; private set; }
        public LicenseRegistrationRequestStatus Status { get; private set; }
        public LicenseId LicenseId { get; private set; }

        private LicenseRegistrationRequest()
        {

        }

        public static LicenseRegistrationRequest CreateNew(string address, string companyName, string email, string contactPerson, LicenseId licenseId)
        {
            var request = new LicenseRegistrationRequest()
            {
                Id = LicenseRegistrationRequestId.GenerateNew(),
                Address = new Address(address),
                ComapnyName = new ComapnyName(companyName),
                Email = new Email(email),
                ContactPerson = new ContactPerson(contactPerson),
                LicenseId = licenseId,
                Status = LicenseRegistrationRequestStatus.New
            };

            request.AddLocalEvent(new NewLicenseRegistrationRequestEvent(request.LicenseId, request.Id));
            return request;
        }

        public void Complete()
        {
            if (Status == LicenseRegistrationRequestStatus.New)
            {
                Status = LicenseRegistrationRequestStatus.Completed;
            }
        }

    }
}
