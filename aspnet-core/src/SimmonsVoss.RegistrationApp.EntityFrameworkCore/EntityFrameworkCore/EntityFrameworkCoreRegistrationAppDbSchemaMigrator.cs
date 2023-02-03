using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimmonsVoss.RegistrationApp.Data;
using Volo.Abp.DependencyInjection;

namespace SimmonsVoss.RegistrationApp.EntityFrameworkCore;

public class EntityFrameworkCoreRegistrationAppDbSchemaMigrator
    : IRegistrationAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreRegistrationAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the RegistrationAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RegistrationAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
