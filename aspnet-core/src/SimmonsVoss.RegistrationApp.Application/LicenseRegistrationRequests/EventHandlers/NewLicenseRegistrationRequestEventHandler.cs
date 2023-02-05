using SimmonsVoss.RegistrationApp.LicenseRegisterationRequests.Events;
using SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.DomainServices;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.EventHandlers
{
    public class NewLicenseRegistrationRequestEventHandler :
                  ILocalEventHandler<NewLicenseRegistrationRequestEvent>,
                  ITransientDependency
    {
        private readonly SignLicenseDomainService _signLicenseDomainService;

        public NewLicenseRegistrationRequestEventHandler(SignLicenseDomainService signLicenseDomainService)
        {
            _signLicenseDomainService = signLicenseDomainService;
        }
        public Task HandleEventAsync(NewLicenseRegistrationRequestEvent eventData)
        {
            // Call External LSG function
            // Call Sign License 
            // in case of failure we should swallow the exception, so that the UOW continues and the request is save to DB
            // then we could develop backround job to sign the new requests 

            return Task.CompletedTask;
        }
    }
}
