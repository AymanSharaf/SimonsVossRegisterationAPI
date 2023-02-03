using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimmonsVoss.RegistrationApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class RegistrationAppDbContextFactory : IDesignTimeDbContextFactory<RegistrationAppDbContext>
{
    public RegistrationAppDbContext CreateDbContext(string[] args)
    {
        RegistrationAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<RegistrationAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new RegistrationAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SimmonsVoss.RegistrationApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
