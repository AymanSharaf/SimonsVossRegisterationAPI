using SimmonsVoss.RegistrationApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SimmonsVoss.RegistrationApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RegistrationAppEntityFrameworkCoreModule),
    typeof(RegistrationAppApplicationContractsModule)
    )]
public class RegistrationAppDbMigratorModule : AbpModule
{

}
