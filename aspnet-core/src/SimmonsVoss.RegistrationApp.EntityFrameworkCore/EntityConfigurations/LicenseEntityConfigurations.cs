using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimmonsVoss.RegistrationApp.Licenses;
using SimmonsVoss.RegistrationApp.Packages;

namespace SimmonsVoss.RegistrationApp.EntityConfigurations
{
    internal class LicenseEntityConfigurations : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.ToTable("Licenses");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => LicenseId.FromExisting(l))
                                        .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Signature,
                b =>
                {
                    b.Property(p => p.Value).HasMaxLength(250)
                    .HasColumnName("LicenseSignature").IsRequired();
                });

            builder.OwnsOne(c => c.LicenseKey,
                b =>
                {
                    b.Property(p => p.Value).HasMaxLength(250)
                    .HasColumnName("LicenseKey").IsRequired();
                });

            builder.HasOne<Package>().WithMany().HasForeignKey(a => a.PackageId);

        }
    }
}
