using Microsoft.EntityFrameworkCore;
using SimmonsVoss.RegistrationApp.Features;
using System.Reflection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace SimmonsVoss.RegistrationApp.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class RegistrationAppDbContext :
    AbpDbContext<RegistrationAppDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Feature> Features { get; set; }

    public RegistrationAppDbContext(DbContextOptions<RegistrationAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        Assembly assemblyWithConfigurations = GetType().Assembly;
        builder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);

        /* Include modules to your migration db context */
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        //builder.ConfigureOpenIddict();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(RegistrationAppConsts.DbTablePrefix + "YourEntities", RegistrationAppConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
