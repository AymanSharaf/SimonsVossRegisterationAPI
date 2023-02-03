﻿using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace SimmonsVoss.RegistrationApp;

[DependsOn(
    typeof(RegistrationAppDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(RegistrationAppApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class RegistrationAppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<RegistrationAppApplicationModule>();
        });
    }
}
