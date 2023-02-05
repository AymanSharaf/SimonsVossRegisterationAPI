using SimmonsVoss.RegistrationApp.LicenseRegisterationRequests;
using SimmonsVoss.RegistrationApp.Licenses;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.DomainServices
{
    public class SignLicenseDomainService : DomainService
    {
        private readonly IRepository<License> _licenseRepository;
        private readonly IRepository<LicenseRegistrationRequest> _licenseRegistrationRepository;

        public SignLicenseDomainService(IRepository<License> licenseRepository,
                                   IRepository<LicenseRegistrationRequest> licenseRegistrationRepository)
        {
            _licenseRepository = licenseRepository;
            _licenseRegistrationRepository = licenseRegistrationRepository;
        }

        public async Task Sign(LicenseId licenseId, LicenseRegistrationRequestId licenseRegistrationRequestId,
                        string signature)
        {
            var license = await _licenseRepository.GetAsync(l => l.Id.ValueEquals(licenseId));
            var request = await _licenseRegistrationRepository.GetAsync(r => r.Id.ValueEquals(licenseRegistrationRequestId));

            license.Sign(signature);
            request.Complete();

            await _licenseRepository.UpdateAsync(license);
            await _licenseRegistrationRepository.UpdateAsync(request, true);
        }
    }
}
