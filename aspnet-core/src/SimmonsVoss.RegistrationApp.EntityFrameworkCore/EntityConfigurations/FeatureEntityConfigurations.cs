using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimmonsVoss.RegistrationApp.Features;

namespace SimmonsVoss.RegistrationApp.EntityConfigurations
{
    public class FeatureEntityConfigurations : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features");

            builder.Property(x => x.Id).HasConversion(x => x.Id, l => FeatureId.FromExisting(l))
                                        .HasColumnName("Id").IsRequired();

            builder.OwnsOne(c => c.Name, b => { b.Property(p => p.Value).HasMaxLength(250).HasColumnName("Name").IsRequired(); });

        }
    }
}
