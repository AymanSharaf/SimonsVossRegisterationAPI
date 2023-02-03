using SimmonsVoss.RegistrationApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppEntityFrameworkCoreTestModule)
    )]
public class RegistrationAppDomainTestModule : AbpModule
{

}
