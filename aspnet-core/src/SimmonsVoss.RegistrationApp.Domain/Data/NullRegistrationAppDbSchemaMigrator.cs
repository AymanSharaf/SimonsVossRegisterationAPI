using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SimmonsVoss.RegistrationApp.Data;

/* This is used if database provider does't define
 * IRegistrationAppDbSchemaMigrator implementation.
 */
public class NullRegistrationAppDbSchemaMigrator : IRegistrationAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
