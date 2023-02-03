using System.Threading.Tasks;

namespace SimmonsVoss.RegistrationApp.Data;

public interface IRegistrationAppDbSchemaMigrator
{
    Task MigrateAsync();
}
