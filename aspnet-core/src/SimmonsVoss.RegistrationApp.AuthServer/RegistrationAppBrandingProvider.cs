using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SimmonsVoss.RegistrationApp;

[Dependency(ReplaceServices = true)]
public class RegistrationAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RegistrationApp";
}
