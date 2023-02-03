using System;
using System.Collections.Generic;
using System.Text;
using SimmonsVoss.RegistrationApp.Localization;
using Volo.Abp.Application.Services;

namespace SimmonsVoss.RegistrationApp;

/* Inherit your application services from this class.
 */
public abstract class RegistrationAppAppService : ApplicationService
{
    protected RegistrationAppAppService()
    {
        LocalizationResource = typeof(RegistrationAppResource);
    }
}
