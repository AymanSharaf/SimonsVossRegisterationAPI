using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.SettingManagement;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppDomainSharedModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class RegistrationAppApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        RegistrationAppDtoExtensions.Configure();
    }
}
