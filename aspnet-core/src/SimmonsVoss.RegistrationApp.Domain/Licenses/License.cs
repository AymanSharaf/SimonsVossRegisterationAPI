using SimmonsVoss.RegistrationApp.Packages;
using Volo.Abp.Domain.Entities.Auditing;

namespace SimmonsVoss.RegistrationApp.Licenses
{
    public class License : AuditedAggregateRoot<LicenseId>
    {
        public LicenseKey Key { get; private set; }
        public LicenseStatus Status { get; private set; }
        public LicenseSignature Signature { get; set; }
        public PackageId PackageId { get; private set; }

        private License()
        {

        }

        public static License CreateNew(string key, PackageId packageId)
        {
            return new License
            {
                Id = LicenseId.GenerateNew(),
                Key = new LicenseKey(key),
                Status = LicenseStatus.New,
                PackageId = packageId
            };
        }

        public void Sign(string signature)
        {
            if (Status == LicenseStatus.New)
            {
                Signature = new LicenseSignature(signature);
                Status = LicenseStatus.Active;
            }
            // Maybe throw Custom Business Exception here if required by business
        }

        public void Deactivate()
        {
            if (Status == LicenseStatus.Active)
            {
                Status = LicenseStatus.Inactive;
            }
        }
    }
}
