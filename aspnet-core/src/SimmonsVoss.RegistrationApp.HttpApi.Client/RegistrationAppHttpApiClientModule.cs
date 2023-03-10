using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppApplicationContractsModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class RegistrationAppHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(RegistrationAppApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RegistrationAppHttpApiClientModule>();
        });
    }
}
