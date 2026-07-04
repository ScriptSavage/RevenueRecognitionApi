using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class SoftwareVersionConfiguration : IEntityTypeConfiguration<SoftwareVersion>
{
    public void Configure(EntityTypeBuilder<SoftwareVersion> builder)
    {
        builder.HasKey(e => e.VersionId);

        builder.Property(e => e.VersionNumber)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(e => e.AnnualPriceInPln)
            .IsRequired();

        builder.Property(e => e.ReleaseYear)
            .IsRequired();
    }
}