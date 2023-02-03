using Localization.Resources.AbpUi;
using SimmonsVoss.RegistrationApp.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppApplicationContractsModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class RegistrationAppHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<RegistrationAppResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
