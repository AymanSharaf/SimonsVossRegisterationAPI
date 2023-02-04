using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimmonsVoss.RegistrationApp.LicenseRegisterationRequests;
using SimmonsVoss.RegistrationApp.Licenses;

namespace SimmonsVoss.RegistrationApp.EntityConfigurations
{
    internal class LicenseRegistrationRequestEntityConfigurations : IEntityTypeConfiguration<LicenseRegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<LicenseRegistrationRequest> builder)
        {
            builder.ToTable("LicenseRegistrationRequests");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => LicenseRegistrationRequestId.FromExisting(l))
                                        .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.ContactPerson,
               b =>
               {
                   b.Property(p => p.Value).HasMaxLength(250)
                   .HasColumnName("ContactPerson").IsRequired();
               });

            builder.OwnsOne(c => c.Address,
               b =>
               {
                   b.Property(p => p.Value).HasMaxLength(250)
                   .HasColumnName("Address").IsRequired();
               });

            builder.OwnsOne(c => c.ComapnyName,
               b =>
               {
                   b.Property(p => p.Value).HasMaxLength(250)
                   .HasColumnName("ComapnyName").IsRequired();
               });

            builder.OwnsOne(c => c.Email,
               b =>
               {
                   b.Property(p => p.Value).HasMaxLength(250)
                   .HasColumnName("Email").IsRequired();
               });

            builder.HasOne<License>().WithMany().HasForeignKey(a => a.LicenseId);

        }
    }
}
