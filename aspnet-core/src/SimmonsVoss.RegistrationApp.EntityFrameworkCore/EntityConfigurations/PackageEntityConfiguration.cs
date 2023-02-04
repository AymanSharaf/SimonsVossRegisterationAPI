using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimmonsVoss.RegistrationApp.Features;
using SimmonsVoss.RegistrationApp.Packages;
using System.Collections.Generic;

namespace SimmonsVoss.RegistrationApp.EntityConfigurations
{
    internal class PackageEntityConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Packages");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => PackageId.FromExisting(l))
                                        .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name,
                b => { b.Property(p => p.Value).HasMaxLength(250).HasColumnName("Name").IsRequired(); });

            builder.Ignore(a => a.Features);

            builder.HasMany<Feature>("_features").WithMany().UsingEntity<Dictionary<string, object>>(
          "PackageFeatures",
          j => j
              .HasOne<Feature>()
              .WithMany()
              .HasForeignKey("FeatureId")
              .OnDelete(DeleteBehavior.Cascade),
          j => j
              .HasOne<Package>()
              .WithMany()
              .HasForeignKey("PackageId")
              .OnDelete(DeleteBehavior.ClientCascade));

        }
    }
}
