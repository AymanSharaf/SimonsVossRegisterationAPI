using SimmonsVoss.RegistrationApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SimmonsVoss.RegistrationApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class RegistrationAppController : AbpControllerBase
{
    protected RegistrationAppController()
    {
        LocalizationResource = typeof(RegistrationAppResource);
    }
}
