using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class SoftwareConfiguration : IEntityTypeConfiguration<Software>
{
    public void Configure(EntityTypeBuilder<Software> builder)
    {
        builder.HasKey(e => e.LicenceId);
        
        builder.Property(e=>e.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(e => e.Version)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasMany(e=>e.SoftwareVersions)
            .WithOne(c=>c.Software)
            .HasForeignKey(k=>k.SoftwareId);
        
        builder.HasMany(e=>e.Discounts)
            .WithOne(c=>c.Software)
            .HasForeignKey(k=>k.SoftwareId);
    }
}