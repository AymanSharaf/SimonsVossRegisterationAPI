using SimmonsVoss.RegistrationApp.LicenseRegisterationRequests;
using SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.Dtos;
using SimmonsVoss.RegistrationApp.Licenses;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests
{
    public class LicenseRegistrationRequestAppService : ApplicationService,
                                              ILicenseRegistrationRequestAppService
    {
        private readonly IRepository<LicenseRegistrationRequest> _licenseRegistrationRequestRepository;
        private readonly IRepository<License> _licenseRepository;

        public LicenseRegistrationRequestAppService(IRepository<LicenseRegistrationRequest> LicenseRegistrationRequestRepository,
                                                    IRepository<License> licenseRepository)
        {
            _licenseRegistrationRequestRepository = LicenseRegistrationRequestRepository;
            _licenseRepository = licenseRepository;
        }
        public async virtual Task<CreateLicenseRegistrationRequestResultDto> CreateAsync(CreateLicenseRegistrationRequestInputDto input)
        {
            var license = await _licenseRepository.FirstOrDefaultAsync(l => l.LicenseKey.Value.Equals(input.LicenseKey) &&
                                                            l.Status == LicenseStatus.New);
            if (license is null)
            {
                throw new UserFriendlyException(message: "Invalid License Key");
            }

            var request = LicenseRegistrationRequest.CreateNew(input.Address, input.ComapnyName,
                                       input.Email, input.ContactPerson, license.Id);

            await _licenseRegistrationRequestRepository.InsertAsync(request);// UOW automatically calls savechanges and raises domain events

            return new CreateLicenseRegistrationRequestResultDto
            {
                Id = request.Id.Id,
                Status = request.Status.ToString(),
            };
        }

        public async virtual Task<LicenseRegistrationRequestDto> GetAsync([Required] Guid requestId)
        {
            var request = await _licenseRegistrationRequestRepository.GetAsync(r => r.Id.Equals(requestId));

            return ObjectMapper.Map<LicenseRegistrationRequest, LicenseRegistrationRequestDto>(request);
        }
    }
}
