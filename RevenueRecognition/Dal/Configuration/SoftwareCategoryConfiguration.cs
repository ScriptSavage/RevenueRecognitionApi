using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration;

public class SoftwareCategoryConfiguration : IEntityTypeConfiguration<SoftwareCategory>
{
    public void Configure(EntityTypeBuilder<SoftwareCategory> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasMany(e=>e.Software)
            .WithOne(c=>c.SoftwareCategory)
            .HasForeignKey(k=>k.CategoryId);
    }
}