using SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests
{
    public interface ILicenseRegistrationRequestAppService : IApplicationService
    {
        Task<CreateLicenseRegistrationRequestResultDto> CreateAsync(CreateLicenseRegistrationRequestInputDto input);
        Task<LicenseRegistrationRequestDto> GetAsync(Guid requestId);
    }
}
