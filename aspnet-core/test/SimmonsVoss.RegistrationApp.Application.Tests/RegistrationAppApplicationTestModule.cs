using Volo.Abp.Modularity;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppApplicationModule),
    typeof(RegistrationAppDomainTestModule)
    )]
public class RegistrationAppApplicationTestModule : AbpModule
{

}
